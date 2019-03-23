using System;
using System.Collections.Generic;
using System.Text;
using CleanQuote.Data.Entities;
using System.Linq;

namespace CleanQuote.Services
{
    class ByDailyChange : IQuotesFilterRule
    {
        private readonly decimal _filter;

        public ByDailyChange(decimal filter)
        {
            _filter = filter;
        }

        public IEnumerable<Quote> FilterQuotes(IEnumerable<Quote> quotes)
        {
            var result = quotes.Where(x => x.DailyChange > _filter).ToList();
            return result;
        }
    }
}
