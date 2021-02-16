using BinanceMonitor.Core.ApiHelpers;
using BinanceMonitor.Core.Responces;
using BinanceMonitor.Core.Responces.TickerPrices;
using BinanceMonitor.Core.Responces.Tickers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BinanceMonitor.Core.Services
{
    class BinanceApiService
    {
        private HttpClient _httpClient;
        public BinanceApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> CheckConnection()
        {
            var res = await _httpClient.GetStringAsync(BinanceRequests.PingRequest);
            return res == "{}";
        }
        public async Task<SymbolResponse> GetListOfAllCurrency()
        {
            var result = await _httpClient.GetStringAsync(BinanceRequests.ExchangeInfoRequest);
            return JsonConvert.DeserializeObject<SymbolResponse>(result);
        }
        public async Task<SymbolPriceTicker> GetChangeSymbol(string symbol)
        {
            var response = await _httpClient.GetStringAsync(BinanceRequests.TickerPrice24Hours + symbol);
            return JsonConvert.DeserializeObject<SymbolPriceTicker>(response);

        }
        public async Task<SymbolChangesTicker> GetPriceOfSymbol(string symbol)
        {
            var responce = await _httpClient.GetStringAsync(BinanceRequests.SymbolTickerPrice + symbol);
            return JsonConvert.DeserializeObject<SymbolChangesTicker>(responce);
        }
        public async Task<AvgOrderBookTicker> GetAvgOrderBookOfSymbol(string symbol)
        {
            var responce = await _httpClient.GetStringAsync(BinanceRequests.AvgOrderBookTicker + symbol);
            return JsonConvert.DeserializeObject<AvgOrderBookTicker>(responce);
        }
        public async Task<OrderBookTicker> GetOrderBookTicker(string symbol, int limit)
        {
            var responce = await _httpClient.GetStringAsync(BinanceRequests.OrderBookTicker+symbol+"&limit="+limit);
            var a = JsonConvert.DeserializeObject<OrderBookTicker>(responce);
            return a;

        }
    }
}
