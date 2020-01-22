using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TradeDataFeed.Interfaces;
using TradeDataFeed.Models;

namespace TradeDataFeed
{
    // Things have changed here with .NETCore. I was hoping to have used MSMQ, but this is dropped with netcore as its windows only.
    // Nservice bus may be a quick replacement, however everything is pushing towards using Azure (or other cloud based queueing)

    // Will leave this in place as a code stub to replace if time permits.

    public class MessageQueue : IMessageQueue
    {

        private Queue<OMSTradeDataMessage> Queue = new Queue<OMSTradeDataMessage>();
        private TradeDataService _tradeDataService;
        private Timer _timer;

        MessageQueue(TradeDataService tradeService) {
            _tradeDataService = tradeService;
        }

        public void PopMessage(OMSTradeDataMessage message)
        {
            Queue.Enqueue(message);
        }

        public void ProcessMessages()
        {

            OMSTradeDataMessage message;
            while (Queue.TryDequeue(out message))
            {
                _tradeDataService.CommitTrades(message);
                Console.WriteLine(message);
            }

        }

        //public Task StartAsync(CancellationToken cancellationToken)
        //{
        //    _timer = new Timer(ProcessMessages, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        //    return Task.CompletedTask;
        //}

        //public Task StopAsync(CancellationToken cancellationToken)
        //{
        //    _timer?.Change(Timeout.Infinite, 0);
        //    return Task.CompletedTask;
        //}

        //public void Dispose()
        //{
        //    _timer?.Dispose();
        //}

    }
}
