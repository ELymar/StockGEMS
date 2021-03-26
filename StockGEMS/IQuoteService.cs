using System.Collections.Generic;

namespace StockGEMS
{
    public interface IQuoteService
    {
        IDictionary<string, double> GetQuotes(string[] tickers);
    }
}