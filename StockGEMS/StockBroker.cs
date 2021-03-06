using System;
using System.Collections.Generic;

namespace StockGEMS
{
    public class StockBroker : IStockBroker
    {
        private readonly string _userName;
        private readonly string _password;
        private readonly ILogger _logger;

        public StockBroker(ILogger logger)
        {
            this._userName = Environment.GetEnvironmentVariable("StockBrokerUserName");
            this._password = Environment.GetEnvironmentVariable("StockBrokerPassword");
            this._logger = logger;
        }

        public bool BuyStocks(IDictionary<string, double> quotes, IDictionary<string, int> stockQuantitiesToBuy)
        {
            //var purchaseContext = ConnectToBroker(_userName, _password).CreatePurchaseContext()
            var total = 0.0;
            foreach (var stock in stockQuantitiesToBuy.Keys)
            {
                _logger.Log($"Ordering {stockQuantitiesToBuy[stock]} shares of {stock} at ${quotes[stock]:0.00} per share");
                //purchaseContext.Add(stock, stockQuantitiesToBuy[stock])
                total += stockQuantitiesToBuy[stock] * quotes[stock];
            }
            //bool executed = purchaseContext.Execute(); 
            _logger.Log($"Order executed. Total cost: ${total:0.00}");
            // return executed 
            return true;
        }
    }
}