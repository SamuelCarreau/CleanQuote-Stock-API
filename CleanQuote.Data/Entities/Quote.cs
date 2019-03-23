using System;
using System.Collections.Generic;
using System.Text;

namespace CleanQuote.Data.Entities
{
    public class Quote
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal MarketCap { get; set; }
        public decimal Price { get; set; }
        public decimal DailyChange { get; set; }
        public double DailyChangePercent { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }
    }

}
