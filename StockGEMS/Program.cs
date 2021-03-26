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
            container.RegisterSingleton<ILogger>(typeof(ConsoleLogger)); 
            container.RegisterSingleton<IStrategy>(typeof(Strategy));
            container.RegisterSingleton<IQuoteService>(typeof(QuoteService)); 
            container.RegisterSingleton<IStockGEMS>(typeof(StockGEMS)); 
            container.RegisterSingleton<IStockBroker>(typeof(StockBroker));

            IStockGEMS stockGems = container.GetObject<IStockGEMS>();
            stockGems.Run(); 

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
