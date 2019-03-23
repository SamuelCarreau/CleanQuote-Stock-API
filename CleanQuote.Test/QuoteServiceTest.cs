using NUnit.Framework;
using NSubstitute;
using CleanQuote.Services;
using CleanQuote.Data.Entities;
using System.Collections.Generic;
using CleanQuote.Data.Repositories;
using System.Linq;

namespace Tests
{
    public class QuoteServiceTest
    {
        private QuoteService _sut;
        private IQuoteRepository _quoteRepository;

        [SetUp]
        public void Setup()
        {
            _quoteRepository = Substitute.For<IQuoteRepository>();
            _sut = new QuoteService(_quoteRepository);
        }

        [Test]
        public void GetQuote_emptyFilter_valid()
        {
            // MOCK

            var quotes = new List<Quote> {
                new Quote(),
                new Quote(),
                new Quote(),
            };

            _quoteRepository.GetQuotes().Returns(quotes);

            // Execute

            var result = _sut.GetQuotes().ToList();

            // Assert

            Assert.AreEqual(3,result.Count);
        }

        [Test]
        public void GetQuote_bycurrency_valid()
        {
            // MOCK

            var quotes = new List<Quote> {
                new Quote{ Currency = "usd" },
                new Quote{ Currency = "can" },
                new Quote{ Currency = "usd" }
            };

            _quoteRepository.GetQuotes().Returns(quotes);

            // Execute

            var filter = new QuotesFilter();
            filter.AddFilterByCurrency("usd");

            var result = _sut.GetQuotes().ToList();
            result = _sut.FilterQuotes(result, filter).ToList();

            // Assert

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(0, result.Count(x => x.Currency == "can"));
            Assert.IsTrue(result.Count == 2);
        }

        [Test]
        public void GetQuote_byDailyChange_valid()
        {
            // MOCK

            var quotes = new List<Quote> {
                new Quote{ DailyChange = 3.12m },
                new Quote{ DailyChange = 0.15m },
                new Quote{ DailyChange = -0.09m }
            };

            _quoteRepository.GetQuotes().Returns(quotes);

            // Execute

            var filter = new QuotesFilter();
            filter.AddFilterByDailyChange(1.0m);

            var result = _sut.GetQuotes().ToList();
            result = _sut.FilterQuotes(result, filter).ToList();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result.Count(x => x.DailyChange == 3.12m));
        }

        [Test]
        public void GetQuote_byMarcketCap_valid()
        {
            // MOCK

            var quotes = new List<Quote> {
                new Quote{ MarketCap = 744.944m },
                new Quote{ MarketCap = 821.3093m },
                new Quote{ MarketCap = 7.84m }
            };

            _quoteRepository.GetQuotes().Returns(quotes);

            // Execute

            var filter = new QuotesFilter();
            filter.AddFilterByMarketCap(100.0m);

            var result = _sut.GetQuotes().ToList();
            result = _sut.FilterQuotes(result, filter).ToList();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result.Count(x => x.MarketCap == 744.944m));
            Assert.AreEqual(1, result.Count(x => x.MarketCap == 821.3093m));
            Assert.AreEqual(0, result.Count(x => x.MarketCap == 7.84m));
        }

        [Test]
        public void GetQuote_byAllFilter_valid()
        {

            // MOCK

            var quotes = new List<Quote> {
                new Quote{Symbol = "AAPL" , DailyChange = 1.35m , MarketCap = 744.944m, Currency = "usd" },
                new Quote{Symbol = "MSFF" ,DailyChange = 0.35m , MarketCap = 744.944m, Currency = "usd" },
                new Quote{Symbol = "RY" ,DailyChange = 1.35m , MarketCap = 142.3m, Currency = "can" },
                new Quote{Symbol = "MSFT" ,DailyChange = 1.095m , MarketCap = 7.84m, Currency = "usd" }
            };

            _quoteRepository.GetQuotes().Returns(quotes);

            // Execute

            var filter = new QuotesFilter();
            filter.AddFilterByMarketCap(100.0m);
            filter.AddFilterByDailyChange(1.0m);
            filter.AddFilterByCurrency("usd");

            var result = _sut.GetQuotes().ToList();
            result = _sut.FilterQuotes(result, filter).ToList();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result.Count(x => x.Symbol == "AAPL"));

        }
    }
}