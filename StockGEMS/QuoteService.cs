using System;
using System.Collections.Generic;

namespace StockGEMS
{
    public class QuoteService : IQuoteService
    {
        private readonly string _apiKey;
        private readonly ILogger _logger;

        public QuoteService(ILogger logger)
        {
            _apiKey = Environment.GetEnvironmentVariable("QuoteServiceApiKey");
            this._logger = logger;
        }

        public IDictionary<string, double> GetQuotes(string[] tickers)
        {
            //var quoteContext = ConnectToQuoteService(_apiKey);
            //return quoteContext.GetStockQuotes(tickers)

            _logger.Log("Connecting to stock quote database. Getting quotes");
            var random = new Random();
            IDictionary<string, double> quotes = new Dictionary<string, double>();
            foreach (var ticker in tickers)
            {
                quotes.Add(ticker, random.NextDouble() * 99 + 1);
            }
            return quotes;
        }
    }
}