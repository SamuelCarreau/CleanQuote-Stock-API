using System;
using System.Collections.Generic;
using System.Text;
using CleanQuote.Data.Entities;
using System.Linq;

namespace CleanQuote.Services
{
    class ByCurrency : IQuotesFilterRule
    {
        private readonly string _filter;

        public ByCurrency(string filter)
        {
            _filter = filter;
        }

        public IEnumerable<Quote> FilterQuotes(IEnumerable<Quote> quotes)
        {
            var result = quotes.Where(x => x.Currency.Equals(_filter)).ToList();
            return result;
        }
    }
}
