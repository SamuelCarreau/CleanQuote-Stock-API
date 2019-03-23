using CleanQuote.Data.Repositories;
using CleanQuote.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanQuote.Services
{
    public interface IQuoteService
    {
        IEnumerable<Quote> GetQuotes();
        IEnumerable<Quote> FilterQuotes(IEnumerable<Quote> quotes, QuotesFilter filter);
    }

    public class QuoteService : IQuoteService
    {

        protected readonly IQuoteRepository _quoteRepository;


        public QuoteService(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        public IEnumerable<Quote> GetQuotes()
        {
            return _quoteRepository.GetQuotes(); 
        }

        public IEnumerable<Quote> FilterQuotes(IEnumerable<Quote> quotes,QuotesFilter filter)
        {
            return filter.FilterQuotes(quotes);
        }
    }
}
