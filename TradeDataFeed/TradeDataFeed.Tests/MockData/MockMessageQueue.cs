using System.Diagnostics;
using TradeDataFeed.Interfaces;
using TradeDataFeed.Models;

namespace TradeDataFeed.Tests.MockData
{
    public class MockMessageQueue : IMessageQueue
    {
        public void PopMessage(OMSTradeDataMessage message)
        {
            Debug.WriteLine(message.OriginalMessage);
        }

        public void ProcessMessages()
        {
            var message = "todo";
        }
    }
}
