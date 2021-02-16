
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BinanceMonitor.Core.Responces.Tickers
{
    public class OrderBookTicker
    {
        [JsonPropertyName("bids")]
        public List<string []> Bids { get; set; }
        [JsonPropertyName("asks")]
        public List< string[]> Asks { get; set; }
    }
}
