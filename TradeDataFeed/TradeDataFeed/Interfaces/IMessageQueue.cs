using TradeDataFeed.Models;

namespace TradeDataFeed.Interfaces
{
    public interface IMessageQueue
    {
        void PopMessage(OMSTradeDataMessage message);
        void ProcessMessages();
    }
}
