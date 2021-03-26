using System;

namespace StockGEMS
{
    public class StockGEMS : IStockGEMS
    {
        private readonly IQuoteService _quoteService;
        private readonly IStrategy _strategy;
        private readonly IStockBroker _purchaser;

        private int DollarAmount { get; set; } = 1000000;

        public StockGEMS(IQuoteService quoteService, IStrategy strategy, IStockBroker stockBroker)
        {
            this._quoteService = quoteService;
            this._strategy = strategy;
            this._purchaser = stockBroker;
        }

        public void Run()
        {
            string[] tickers = { "GME", "BSY", "AAPL", "TSLA" };
            // Get prices
            var quotes = _quoteService.GetQuotes(tickers);
            // Apply strategy and get list to buy
            var stockQuantitiesToBuy = _strategy.GenerateAllocation(DollarAmount, quotes);
            // Buy buy buy!
            bool success = _purchaser.BuyStocks(quotes, stockQuantitiesToBuy);
            // Hodl stonks
        }
    }
}