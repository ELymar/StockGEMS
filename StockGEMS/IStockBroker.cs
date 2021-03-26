using System.Collections.Generic;

namespace StockGEMS
{
    public interface IStockBroker
    {
        bool BuyStocks(IDictionary<string, double> quotes, IDictionary<string, int> stockQuantitiesToBuy);
    }
}