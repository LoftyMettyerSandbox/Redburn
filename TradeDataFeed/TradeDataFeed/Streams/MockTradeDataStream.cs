using System.IO;
using System.Text;
using TradeDataFeed.Interfaces;

namespace TradeDataFeed.Streams
{
    public class MockTradeDataStream : ITradeDataStream
    {
        public Stream GetTradeStream()
        {
            var path = Directory.GetCurrentDirectory() + "\\MockData\\MockTradeData.txt";
            string jsonData = File.ReadAllText(path);

            return new MemoryStream(Encoding.UTF8.GetBytes(jsonData ?? ""));
        }
    }
}
