using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TradeDataFeed.Interfaces;
using TradeDataFeed.Models;

namespace TradeDataFeed.Tests.MockData
{
    class MockTradeContext : ITradeDataContext
    {
        public void CommitTrade(OMSTradeData trade)
        {
            throw new System.NotImplementedException();
        }

        public bool CommitTrades(IEnumerable<OMSTradeData> trades)
        {
            foreach(OMSTradeData trade in trades) {
                Debug.WriteLine(trade.Identifier);
                //Console.WriteLine(trade.Identifier);
            }
            return true;
        }

        //public IEnumerable<OMSTradeData>GetTradeStream()
        public Stream GetTradeStream()
        {

            var path = Directory.GetCurrentDirectory() + "\\MockData\\MockTradeData.txt";
            string jsonData = File.ReadAllText(path);

            //            var tradeData = JsonConvert.DeserializeObject<IList<OMSTradeData>>(jsonData);
            //            return tradeData;

            return new MemoryStream(Encoding.UTF8.GetBytes(jsonData ?? ""));

        }
    }
}
