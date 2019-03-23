using System;
using System.Collections.Generic;
using System.Text;
using CleanQuote.Data.Entities;

namespace CleanQuote.Services
{
    public interface IQuotesFilterRule
    {
        IEnumerable<Quote> FilterQuotes(IEnumerable<Quote> quotes);
    }
}
