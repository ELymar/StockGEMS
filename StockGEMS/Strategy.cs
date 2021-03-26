using System;
using System.Collections.Generic;

namespace StockGEMS
{
    public class Strategy : IStrategy
    {
        private readonly ILogger _logger;

        public Strategy(ILogger logger)
        {
            this._logger = logger;
        }

        public IDictionary<string, int> GenerateAllocation(double dollarAmount, IDictionary<string, double> quotes)
        {
            _logger.Log("Generating 80/20 strategy of GME and BSY");
            // 80/20 strategy of GME and BSY
            IDictionary<string, int> stocksToBuy = new Dictionary<string, int>();
            stocksToBuy.Add("GME", (int)(Math.Floor(dollarAmount * 0.8 / quotes["GME"])));
            stocksToBuy.Add("BSY", (int)(Math.Floor(dollarAmount * 0.2 / quotes["BSY"])));
            return stocksToBuy;
        }
    }
}