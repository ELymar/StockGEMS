using System;

namespace StockGEMS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StockGEMS stockTrader = new StockGEMS();
            stockTrader.Run(); 
        }
    }
}
