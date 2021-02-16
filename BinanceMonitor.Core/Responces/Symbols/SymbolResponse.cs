using BinanceMonitor.Core.Responces.Symbols;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BinanceMonitor.Core.Responces
{
    public class SymbolResponse
    {
        [JsonPropertyName("symbols")]
        public List<TradeSymbol> symbols { get; set; }
    }
}
