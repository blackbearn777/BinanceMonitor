using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BinanceMonitor.Core.Responces.Tickers
{
    public class AvgOrderBookTicker
    {
        [JsonPropertyName("bidPrice")]
        public double BidPrice { get; set; }
        [JsonPropertyName("bidQty")]
        public double BidCount { get; set; }
        [JsonPropertyName("askPrice")]
        public double AskPrice { get; set; }
        [JsonPropertyName("askQty")]
        public double AskCount { get; set; }
    }
}
