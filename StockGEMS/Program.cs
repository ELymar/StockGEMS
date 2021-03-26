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
            container.RegisterSingleton(typeof(ILogger), typeof(ConsoleLogger)); 
            container.RegisterSingleton(typeof(IStrategy), typeof(Strategy));
            container.RegisterSingleton(typeof(IQuoteService), typeof(QuoteService)); 
            container.RegisterSingleton(typeof(IStockGEMS), typeof(StockGEMS)); 
            container.RegisterSingleton(typeof(IStockBroker), typeof(StockBroker));

            IStockGEMS stockGems = (IStockGEMS)container.GetObject(typeof(IStockGEMS));
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
