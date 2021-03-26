using System;

namespace StockGEMS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Build 
            IQuoteService quoteService = new QuoteService(
                new ConsoleLogger()
            );
            IStrategy strategy = new Strategy(
                new ConsoleLogger()
            );
            IStockBroker purchaser = new StockBroker(
                new ConsoleLogger()
            );
            IStockGEMS stockTrader = new StockGEMS(quoteService, strategy, purchaser);
            stockTrader.Run(); 
        }
    }
}
