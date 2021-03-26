using System;

namespace StockGEMS
{
    public class StockGEMS : IStockGEMS
    {
        private IQuoteService _quoteService;
        private IStrategy _strategy;
        private IStockBroker _purchaser;

        private int DollarAmount { get; set; } = 1000000;

        public StockGEMS()
        {
            this._quoteService = new QuoteService();
            this._strategy = new Strategy();
            this._purchaser = new StockBroker();
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