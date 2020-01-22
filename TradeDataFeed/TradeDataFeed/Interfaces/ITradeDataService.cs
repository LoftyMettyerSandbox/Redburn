using TradeDataFeed.Models;

namespace TradeDataFeed.Interfaces
{
    public interface ITradeDataService
    {
        //bool CommitTrades(OMSTradeDataMessage tradeMessage);
        bool AddTrade(OMSTradeDataMessage tradeMessage);
    }
}
