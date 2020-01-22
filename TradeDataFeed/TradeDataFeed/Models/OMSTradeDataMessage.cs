using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TradeDataFeed.Enums;

namespace TradeDataFeed.Models
{
    public class OMSTradeDataMessage
    {

        public IList<OMSTradeData> Trades;
        public MessageValidityType Validity;

        public string OriginalMessage;

        public OMSTradeDataMessage(Stream streamData) {

            streamData.Position = 0;
            using (StreamReader reader = new StreamReader(streamData, Encoding.UTF8))
            {
                PopulateMessage(reader.ReadToEnd());
            }

        }

        public OMSTradeDataMessage(string jsonData) {
            PopulateMessage(jsonData);
            }

        private void PopulateMessage(string stringData) {
            OriginalMessage = stringData;
            try
            {                
                Trades = JsonConvert.DeserializeObject<IList<OMSTradeData>>(stringData.ToString());
                Validity = MessageValidityType.Success;
            }
            catch
            {
                Validity = MessageValidityType.Failure;
            }
        }


    }
}
