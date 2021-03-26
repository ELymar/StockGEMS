using System;

namespace StockGEMS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IStockGEMS stockTrader = new StockGEMS();
            stockTrader.Run(); 
        }
    }
}
