using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CleanQuote.Data.Entities;

namespace CleanQuote.Services
{
    class ByMarketCap : IQuotesFilterRule
    {

        private readonly decimal _filter;

        public ByMarketCap(decimal filter)
        {
            _filter = filter;
        }

        public IEnumerable<Quote> FilterQuotes(IEnumerable<Quote> quotes)
        {
            var result = quotes.Where(x => x.MarketCap > _filter).ToList();
            return result;
        }
    }
}
