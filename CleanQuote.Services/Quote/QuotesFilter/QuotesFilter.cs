using System;
using System.Collections.Generic;
using System.Text;
using CleanQuote.Data.Entities;

namespace CleanQuote.Services
{
    public class QuotesFilter : IQuotesFilterRule
    {
        private IQuotesFilterRule _byDailyChange;
        private IQuotesFilterRule _byMarketCap;
        private IQuotesFilterRule _byCurrency;

        public List<IQuotesFilterRule> FilterRules { get; set; }

        public QuotesFilter()
        {
            FilterRules = new List<IQuotesFilterRule>();
        }

        public IEnumerable<Quote> FilterQuotes(IEnumerable<Quote> quotes)
        {
            foreach (IQuotesFilterRule rule in FilterRules)
            {
                quotes = rule.FilterQuotes(quotes);
            }
            return quotes;
        }

        public void AddFilterByDailyChange(decimal filter)
        {
            if(_byDailyChange == null)
            {
                _byDailyChange = new ByDailyChange(filter);
                FilterRules.Add(_byDailyChange);
            }
        }

        public void AddFilterByMarketCap(decimal filter)
        {
            if(_byMarketCap == null)
            {
                _byMarketCap = new ByMarketCap(filter);
                FilterRules.Add(_byMarketCap);
            }
        }

        public void AddFilterByCurrency(string filter)
        {
            if(_byCurrency == null)
            {
                _byCurrency = new ByCurrency(filter);
                FilterRules.Add(_byCurrency);
            }
        }
    }
}
