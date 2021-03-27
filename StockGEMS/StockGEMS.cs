using System;

namespace StockGEMS
{
    public class StockGEMS : IStockGEMS
    {
        private readonly IQuoteService _quoteService;
        private readonly IStrategy _strategy;
        private readonly IStockBroker _purchaser;
        private readonly ILogger _logger;

        public StockGEMS(IQuoteService quoteService, IStrategy strategy, IStockBroker stockBroker, ILogger logger)
        {
            this._quoteService = quoteService;
            this._strategy = strategy;
            this._purchaser = stockBroker;
            this._logger = logger;
        }

        public bool Run(int dollarAmount)
        {
            bool didSucceed = false; 
            if(dollarAmount <= 0)
            {
                _logger.Log("Dollar amount must be greater than $0");
                return didSucceed = false;  
            }
            
            string[] tickers = { "GME", "BSY", "AAPL", "TSLA" };
            // Get prices
            var quotes = _quoteService.GetQuotes(tickers);
            // Apply strategy and get list to buy
            var stockQuantitiesToBuy = _strategy.GenerateAllocation(dollarAmount, quotes);
            // Buy buy buy!
            didSucceed = _purchaser.BuyStocks(quotes, stockQuantitiesToBuy);
            // Hodl stonks
            return didSucceed; 
        }
    }
}