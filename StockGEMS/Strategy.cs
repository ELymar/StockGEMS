using System;
using System.Collections.Generic;

namespace StockGEMS
{
    internal class Strategy
    {
        public Strategy()
        {

        }

        internal IDictionary<string, int> GenerateAllocation(double dollarAmount, IDictionary<string, double> quotes)
        {
            Console.WriteLine("Generating 80/20 strategy of GME and BSY"); 
            // 80/20 strategy of GME and BSY
            IDictionary<string, int> stocksToBuy = new Dictionary<string, int>();
            stocksToBuy.Add("GME", (int)(Math.Floor(dollarAmount * 0.8 / quotes["GME"])));
            stocksToBuy.Add("BSY", (int)(Math.Floor(dollarAmount * 0.2 / quotes["BSY"])));
            return stocksToBuy; 
        }
    }
}