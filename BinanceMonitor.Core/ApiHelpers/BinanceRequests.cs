using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceMonitor.Core.ApiHelpers
{
    class BinanceRequests
    {
        public static  string PingRequest { get;  set; } = "https://api.binance.com/api/v1/ping";
        public static string ExchangeInfoRequest { get; set; } = "https://api.binance.com/api/v1/exchangeInfo";
        public static string TickerPrice24Hours { get; set; } = "https://api.binance.com/api/v3/ticker/24hr?symbol=";
        public static string SymbolTickerPrice { get; set; } = "https://api.binance.com/api/v3/ticker/price?symbol=";
        public static string AvgOrderBookTicker { get; set; } = "https://api.binance.com/api/v3/ticker/bookTicker?symbol=";
        public static string OrderBookTicker { get; set; } = "https://api.binance.com/api/v3/depth?symbol=";

    }
}
