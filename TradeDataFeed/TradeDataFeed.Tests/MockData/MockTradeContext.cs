//using System.IO;
//using System.Text;
//using TradeDataFeed.Interfaces;
//using TradeDataFeed.Models;

//namespace TradeDataFeed.Tests.MockData
//{
//    class MockTradeContext : ITradeDataContext
//    {
//        public void CommitTrade(OMSTradeData trade)
//        {
//            throw new System.NotImplementedException();
//        }


//        public Stream GetTradeStream()
//        {

//            var path = Directory.GetCurrentDirectory() + "\\MockData\\MockTradeData.txt";
//            string jsonData = File.ReadAllText(path);

//            //            var tradeData = JsonConvert.DeserializeObject<IList<OMSTradeData>>(jsonData);
//            //            return tradeData;

//            return new MemoryStream(Encoding.UTF8.GetBytes(jsonData ?? ""));

//        }
//    }
//}
