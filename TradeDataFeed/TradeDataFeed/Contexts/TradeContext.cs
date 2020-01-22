using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TradeDataFeed.Interfaces;
using TradeDataFeed.Models;

namespace TradeDataFeed.Contexts
{
    public class TradeContext : DbContext, ITradeDataContext
    {

        private readonly TradeContext _context;

        public TradeContext(DbContextOptions<TradeContext> options) : base(options) { }

        public DbSet<OMSTradeData> TradeData { get; set; }
        public DbSet<MessageBin> Messages { get; set; }

        public bool CommitTrades(IEnumerable<OMSTradeData>trades)
        {
            TradeData.AddRange(trades);
            SaveChanges();
            return true;
        }


        public bool CommitMessage(MessageBin message)
        {
            Messages.AddRange(message);
            SaveChanges();
            return true;
        }

    }
}
