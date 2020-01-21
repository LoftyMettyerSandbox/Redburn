using TradeDataFeed.Controllers;
using Xunit;

namespace TradeDataFeed.Tests
{
    public class DataTests
    {
        [Fact]
        public void DataFeed_Returns_ValidData()
        {

            var serviceAPI = new ValuesController();
            var data = serviceAPI.Get(1);
            Assert.NotNull(data.Value);

        }
    }
}
