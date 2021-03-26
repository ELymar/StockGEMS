using System;

namespace StockGEMS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Build 
            IQuoteService quoteService = new QuoteService();
            IStrategy strategy = new Strategy();
            IStockBroker purchaser = new StockBroker();
            IStockGEMS stockTrader = new StockGEMS(quoteService, strategy, purchaser);
            stockTrader.Run(); 
        }
    }
}
