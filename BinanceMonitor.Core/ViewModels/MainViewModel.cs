using BinanceMonitor.Core.Repositories;
using BinanceMonitor.Core.Responces.Symbols;
using BinanceMonitor.Core.Responces.Tickers;
using BinanceMonitor.Core.Services;
using MvvmCross;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BinanceMonitor.Core.ViewModels
{
    class MainViewModel : MvxViewModel
    {
        private SymbolRepository _symbolRepository;
        private TradeSymbol selectedSymbol;
        private BinanceApiService _binanceApiService;
        private string _pattern;
        private bool _allowWorking;
        public List<TradeSymbol> AllSymbols { get; set; }
        public List<TradeSymbol> SymbolsList { get; set; }
        public string Symbol { get; set; }
        public string PrevPrice { get; set; } = "0";
        public string LastPrice { get; set; } = "0";
        public string PriceChange { get; set; }
        public string PriceChangePercent { get; set; }
        public List<string []> Bids { get; set; }
        public List<string[]> Asks { get; set; }
        public TradeSymbol SelectedSymbol
        {
            get => selectedSymbol;
            set
            {

                selectedSymbol = value;
                _allowWorking = true;
                Symbol = value.Symbol;
                RaisePropertyChanged(() => Symbol);
            }

        }
        public string Pattern
        {
            get => _pattern;
            set
            {
                _pattern = value;
                SelectedSymbol = AllSymbols.FirstOrDefault(a => a.Symbol.ToLower().StartsWith(Pattern.ToLower()));
                SymbolsList = AllSymbols.Where(a => a.Symbol.ToLower().Contains(Pattern.ToLower())).ToList();
                if (Pattern == String.Empty)
                {
                    SymbolsList = AllSymbols;
                }
                RaisePropertyChanged(() => SymbolsList);
                RaisePropertyChanged(() => SelectedSymbol);
            }
        }
        public   MainViewModel()
        {
            _symbolRepository = Mvx.IoCProvider.Resolve<SymbolRepository>();
            _binanceApiService = Mvx.IoCProvider.Resolve<BinanceApiService>();
            AllSymbols = _symbolRepository.GetAllSymbols().ToList();
            //Task checker = new Task(UpdateValues);
            SelectedSymbol = AllSymbols.First();
            //checker.Start();
            SymbolsList = AllSymbols;

            Task.Run(UpdateOrderBook);
            Task.Run(UpdateValues);
            Task.Run(UpdatePrice);
        }
        private async Task UpdateValues()
        {
            while (true)
            {
                if (_allowWorking)
                {

                    var responce = await _binanceApiService.GetChangeSymbol(SelectedSymbol.Symbol);
                    PriceChange = Math.Round(responce.PriceChange,6).ToString();
                    PriceChangePercent ="  "+ responce.PriceChangePercent.ToString() + " %";
                    await RaisePropertyChanged(() => PriceChange);
                    await RaisePropertyChanged(() => PriceChangePercent);
                }

            };
        }
        private async Task UpdatePrice()
        {
            while (true)
            {
                if (_allowWorking)
                {
                    var res = await _binanceApiService.GetPriceOfSymbol(SelectedSymbol.Symbol);
                    PrevPrice = LastPrice;
                    await RaisePropertyChanged(() => PrevPrice);
                    LastPrice = Math.Round(res.Price, 6).ToString();
                    await RaisePropertyChanged(() => LastPrice);
                }
            }
        }
        private async Task UpdateOrderBook()
        {
            while (true)
            {
                if (_allowWorking)
                {
                    var res = await _binanceApiService.GetOrderBookTicker(SelectedSymbol.Symbol, 10);
                    Bids = res.Bids;
                    await RaisePropertyChanged(() => Bids);
                    Asks = res.Asks;
                    await RaisePropertyChanged(() => Asks);

                }
            }
        }
    }
}
