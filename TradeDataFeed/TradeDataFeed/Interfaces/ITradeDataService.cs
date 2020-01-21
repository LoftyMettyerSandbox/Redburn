using TradeDataFeed.Models;

namespace TradeDataFeed.Interfaces
{
    public interface ITradeDataService
    {
        OMSTradeData GetData(int tradeId);
    }
}
