using System.IO;

namespace TradeDataFeed.Interfaces
{
    public interface ITradeDataStream
    {
        Stream GetTradeStream();
    }
}
