using TradeDataFeed.Interfaces;

namespace TradeDataFeed.Tests.MockData
{
    class MockTradeDataService : ITradeDataService
    {
        public string GetData()
        {
            return "mock";
        }
    }
}
