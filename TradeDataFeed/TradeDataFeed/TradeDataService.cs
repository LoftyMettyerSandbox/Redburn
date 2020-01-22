using System;
using System.Collections.Generic;
using TradeDataFeed.Enums;
using TradeDataFeed.Interfaces;
using TradeDataFeed.Models;

namespace TradeDataFeed
{
    public class TradeDataService : ITradeDataService //, IMessageQueue
    {

        private readonly ITradeDataContext _context;
        private Queue<OMSTradeDataMessage> Queue = new Queue<OMSTradeDataMessage>();

        public TradeDataService(ITradeDataContext context) //, IMessageQueue queue)
        {
            _context = context;
        //    _messageQueue = queue;
        }


        public bool AddTrade(OMSTradeDataMessage tradeMessage) {
            Queue.Enqueue(tradeMessage);
            ProcessMessages();
            return true;
        }

        public void ProcessMessages()
        {

            OMSTradeDataMessage message;
            while (Queue.TryDequeue(out message))
            {
                CommitTrades(message);
                Console.WriteLine(message);
            }

        }

        private bool CommitTrades(OMSTradeDataMessage tradeMessage)
        {

      //      _messageQueue.PopMessage(tradeMessage);

        //    _messageQueue.ProcessMessages();

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

        //public void PopMessage(OMSTradeDataMessage message)
        //{
        //    throw new NotImplementedException();
        //}

        //public void ProcessMessages()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
