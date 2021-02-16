using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BinanceMonitor.Core.Responces.TickerPrices
{
    class SymbolChangesTicker
    {
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}
