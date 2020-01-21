using TradeDataFeed.Controllers;
using TradeDataFeed.Tests.MockData;
using Xunit;

namespace TradeDataFeed.Tests
{
    public class DataTests
    {

        private MockTradeDataService _tradeDataService = new MockTradeDataService();

        [Fact]
        public void DataFeed_Returns_ValidData()
        {

            var serviceAPI = new TradesController(_tradeDataService);
            var data = serviceAPI.Get(1);
            Assert.NotNull(data.Value);

        }
    }
}
