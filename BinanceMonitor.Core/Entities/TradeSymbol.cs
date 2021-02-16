using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BinanceMonitor.Core.Responces.Symbols
{
    public class TradeSymbol
    {
        public int Id { get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        public TradeSymbol(string symbol)
        {
            Symbol = symbol;
        }
    }
}
