using System.Collections.Generic;
using System.Threading.Tasks;
using TradeDataFeed.Models;

namespace TradeDataFeed.Interfaces
{
    public interface ITradeDataContext
    {
    //    OMSTradeData GetData(int tradeId);
//        void CommitTrade(OMSTradeData trade);
        bool CommitTrades(IEnumerable<OMSTradeData>trades);

    }
}
