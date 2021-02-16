using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BinanceMonitor.Core.Responces.TickerPrices
{
    public class SymbolPriceTicker
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("priceChange")]
        public decimal PriceChange { get; set; }

        [JsonPropertyName("priceChangePercent")]
        public double PriceChangePercent { get; set; }

        [JsonPropertyName("openPrice")]
        public decimal OpenPrice { get; set; }

        [JsonPropertyName("highPrice")]
        public decimal HighPrice { get; set; }

        [JsonPropertyName("lowPrice")]
        public decimal LowPrice { get; set; }

        [JsonPropertyName("lastPrice")]
        public decimal LastPrice { get; set; }

        [JsonPropertyName("lastQty")]
        public decimal LastQty { get; set; }
    }
}
