using System;
using System.Collections.Generic;
using System.Text;

namespace StockGEMS
{
    public class ConsoleLogger : ILogger
    {
        private static int totalLoggers = 0;
        private readonly int loggerId; 

        public ConsoleLogger()
        {
            loggerId = ++totalLoggers; 
        }
        public void Log(string message)
        {
            Console.WriteLine($"Logger[{loggerId}] {message}");
        }
    }
}
