using BinanceMonitor.Core.Responces.Symbols;
using MvvmCross;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BinanceMonitor.Core.Repositories
{
    public class SymbolRepository
    {
        private ApplicationContext _appContext;
        public SymbolRepository()
        {
            _appContext = Mvx.IoCProvider.Resolve<ApplicationContext>();
        }
        public ICollection<TradeSymbol> GetAllSymbols()
        {
            return _appContext.Symbols.ToList();
        }
        public async void AddSymbols(IEnumerable<TradeSymbol> tradeSymbols)
        {
            try
            {
                foreach (var symbol in tradeSymbols)
                {
                    if (!_appContext.Symbols.Contains(symbol))
                    {
                        await _appContext.Symbols.AddAsync(symbol);

                        await _appContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public async void AddSymbol(TradeSymbol tradeSymbol)
        {
            try
            {
                if (!_appContext.Symbols.Contains(tradeSymbol))
                {
                    await _appContext.AddAsync(tradeSymbol);
                    await _appContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public async void RemoveSymbol(TradeSymbol tradeSymbol)
        {
            try
            {
                if (_appContext.Symbols.Contains(tradeSymbol))
                {
                    _appContext.Symbols.Remove(tradeSymbol);
                    await _appContext.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
