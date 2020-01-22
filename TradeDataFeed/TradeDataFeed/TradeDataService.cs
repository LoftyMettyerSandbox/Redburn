using System;
using TradeDataFeed.Enums;
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

        public bool CommitTrades(OMSTradeDataMessage tradeMessage)
        {

            if (tradeMessage.Validity == MessageValidityType.Success)
            {
                _context.CommitTrades(tradeMessage.Trades);
            }
            else
            {
                // Send to bin
                var message = new MessageBin()
                {
                    ReceivedDate = DateTime.Now,
                    Message = tradeMessage.OriginalMessage,
                    ValidityType = tradeMessage.Validity
                };

                _context.CommitMessage(message);

            }

            return true;
        }



    }
}
