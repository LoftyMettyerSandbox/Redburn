using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TradeDataFeed.Interfaces;
using TradeDataFeed.Models;

namespace TradeDataFeed
{
    public class TradeDataService
    {

        private readonly ITradeDataContext _context;

        public TradeDataService(ITradeDataContext context)
        {
            _context = context;
        }

        //public OMSTradeData GetData(int tradeId)
        //{
        //    return null;
        //}

        public bool CommitTrades(Stream input)
        {

            if (ValidateStream(input))
            {
                var trades = StreamToEnumerable(input);
                _context.CommitTrades(trades);
            }

            //}
            //   }
            //        _context.CommitTrades
            //    _context.TradeData.Add(trade);
            return true;
        }

        public IEnumerable<OMSTradeData>StreamToEnumerable(Stream tradeStream) {

            StreamReader reader = new StreamReader(tradeStream);
            string trades = reader.ReadToEnd();

            var tradeData = JsonConvert.DeserializeObject<IList<OMSTradeData>>(trades);

            //return new List<OMSTradeData>();
            return tradeData;
        }

        public bool ValidateStream(Stream trades) {
            return true;
        }

    }
}
