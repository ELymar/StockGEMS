using System.Collections.Generic;

namespace StockGEMS
{
    public interface IStrategy
    {
        IDictionary<string, int> GenerateAllocation(double dollarAmount, IDictionary<string, double> quotes);
    }
}