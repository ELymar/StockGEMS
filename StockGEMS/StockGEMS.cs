using System;

namespace StockGEMS
{
    internal class StockGEMS
    {
        private QuoteService _quoteService;
        private Strategy _strategy;
        private StockBroker _purchaser;

        private int DollarAmount { get; set; } = 1000000; 

        public StockGEMS()
        {
            this._quoteService = new QuoteService();
            this._strategy = new Strategy();
            this._purchaser = new StockBroker(); 
        }

        internal void Run()
        {
            string[] tickers = { "GME", "BSY", "AAPL", "TSLA" };
            // Get prices
            var quotes = _quoteService.GetQuotes(tickers);
            // Apply strategy and get list to buy
            var stockQuantitiesToBuy = _strategy.GenerateAllocation(DollarAmount, quotes);
            // Buy buy buy!
            _purchaser.BuyStocks(quotes, stockQuantitiesToBuy); 
            // Hodl stonks
        }
    }
}