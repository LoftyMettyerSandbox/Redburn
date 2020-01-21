using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TradeDataFeed.Interfaces;
using TradeDataFeed.Models;

namespace TradeDataFeed.Tests.MockData
{
    class MockTradeDataService : ITradeDataService
    {
        public OMSTradeData GetData(int tradeId)
        {

            var path = Directory.GetCurrentDirectory() + "\\MockData\\MockTradeData.txt";
            string jsonData = File.ReadAllText(path);

            var tradeData = JsonConvert.DeserializeObject<IList<OMSTradeData>>(jsonData);
            return tradeData[0];
        }
    }
}
