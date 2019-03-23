using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanQuote.Data;
using CleanQuote.Data.Entities;
using CleanQuote.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace CleanQuoteAPI.Controllers
{
    [Route("stock/[controller]/")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private const string CACHED_QOTES = "CACHED_QOTES";

        private IMemoryCache _cache;
        private readonly IQuoteService _quoteService;
        private readonly JsonSerializerSettings _jsonSettings;

        public QuotesController(IMemoryCache memoryCache, IQuoteService quoteService)
        {
            _cache = memoryCache;
            _quoteService = quoteService;
            _jsonSettings = new JsonSerializerSettings
            {
                DateFormatString = "dd-MM-yyyy"
            };
        }

        // GET stock/quotes/?marketcap=100&dailchange=1&currency=usd
        [HttpGet]
        public JsonResult Get(
            [FromQuery(Name = "marketcap")]decimal? marketcap,
            [FromQuery(Name = "dailchange")]decimal? dailchange,
            [FromQuery(Name = "currency")]string currency
            )
        {
            var filter = new QuotesFilter();

            // Load quote in memory or in file if not cached
            if (!_cache.TryGetValue(CACHED_QOTES, out IEnumerable<Quote> quotes))
            {
                quotes = _quoteService.GetQuotes();
                _cache.Set("CACHED_QOTES", quotes);
            }

            if (marketcap != null)
                filter.AddFilterByMarketCap((decimal)marketcap);
            if (dailchange != null)
                filter.AddFilterByDailyChange((decimal)dailchange);
            if (currency != null)
                filter.AddFilterByCurrency(currency.ToUpper());

            quotes = _quoteService.FilterQuotes(quotes,filter);

            return new JsonResult(quotes, _jsonSettings);
        }
    }
}
