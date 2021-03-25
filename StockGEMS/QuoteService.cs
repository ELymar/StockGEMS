using System;
using System.Collections.Generic;

namespace StockGEMS
{
    public class QuoteService
    {
        private readonly string _apiKey;

        public QuoteService()
        {
            _apiKey = Environment.GetEnvironmentVariable("QuoteServiceApiKey"); 
        }

        public IDictionary<string, double> GetQuotes(string[] tickers)
        {
            //var quoteContext = ConnectToQuoteService(_apiKey);
            //return quoteContext.GetStockQuotes(tickers)
            
            Console.WriteLine("Connecting to stock quote database. Getting quotes");
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