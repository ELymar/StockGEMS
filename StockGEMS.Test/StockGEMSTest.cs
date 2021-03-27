using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace StockGEMS.Test
{
    [TestClass]
    public class StockGEMSTest
    {
        [TestMethod]
        public void GivenEnoughMoney_WhenRunning_OrderSucceeds()
        {
            var mockLogger = new Mock<ILogger>();
            var mockQuoteService = new Mock<IQuoteService>(); 
            mockQuoteService.Setup(q => q
                .GetQuotes(It.IsAny<string[]>()))
                .Returns(new Dictionary<string, double> { });
            var mockStrategy = new Mock<IStrategy>(); 
            mockStrategy.Setup(s => s
                .GenerateAllocation(It.IsAny<double>(), It.IsAny<Dictionary<string, double>>()))
                .Returns(new Dictionary<string, int>{ });
            
            var mockStockBroker = new Mock<IStockBroker>();
            mockStockBroker.Setup(s => s
                .BuyStocks(It.IsAny<IDictionary<string, double>>(), It.IsAny<IDictionary<string, int>>()))
                .Returns(true); 

            var systemUnderTest = new StockGEMS(
                mockQuoteService.Object,
                mockStrategy.Object,
                mockStockBroker.Object,
                mockLogger.Object);

            Assert.IsTrue(systemUnderTest.Run(1000)); 
        }

        [TestMethod]
        public void GivenLessThanZero_WhenRunning_OrderFails()
        {
            var mockLogger = new Mock<ILogger>();
            var mockQuoteService = new Mock<IQuoteService>();
            mockQuoteService.Setup(q => q
                .GetQuotes(It.IsAny<string[]>()))
                .Returns(new Dictionary<string, double> { });
            var mockStrategy = new Mock<IStrategy>();
            mockStrategy.Setup(s => s
                .GenerateAllocation(It.IsAny<double>(), It.IsAny<Dictionary<string, double>>()))
                .Returns(new Dictionary<string, int> { });

            var mockStockBroker = new Mock<IStockBroker>();
            mockStockBroker.Setup(s => s
                .BuyStocks(It.IsAny<IDictionary<string, double>>(), It.IsAny<IDictionary<string, int>>()))
                .Returns(true);

            var systemUnderTest = new StockGEMS(
                mockQuoteService.Object,
                mockStrategy.Object,
                mockStockBroker.Object,
                mockLogger.Object);

            Assert.IsFalse(systemUnderTest.Run(-1024));


        }
    }
}

