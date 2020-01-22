using System.Collections.Generic;
using System.Threading.Tasks;
using TradeDataFeed.Models;

namespace TradeDataFeed.Interfaces
{
    public interface ITradeDataContext
    {
        bool CommitTrades(IEnumerable<OMSTradeData>trades);
        bool CommitMessage(MessageBin message);
    }
}
