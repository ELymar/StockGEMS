using System;

namespace StockGEMS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Build 
            Container container = new Container();

            //container.RegisterSingleton<ILogger, ConsoleLogger>(); 
            container.RegisterTransient<ILogger, ConsoleLogger>();

            container.RegisterSingleton<IStrategy, Strategy>();
            container.RegisterSingleton<IQuoteService, QuoteService>(); 
            container.RegisterSingleton<IStockGEMS, StockGEMS>(); 
            container.RegisterSingleton<IStockBroker, StockBroker>();

            IStockGEMS stockGems = container.GetObject<IStockGEMS>();
            bool success = stockGems.Run(1000000); 

            /*
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
            */
        }
    }
}
