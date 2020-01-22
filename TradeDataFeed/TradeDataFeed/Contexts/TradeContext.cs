using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TradeDataFeed.Interfaces;
using TradeDataFeed.Models;

namespace TradeDataFeed.Contexts
{
    public class TradeContext : DbContext, ITradeDataContext
    {

        private readonly TradeContext _context;

        //public TradeContext(TradeContext context)
        //{
        //    _context = context;
        //}
        public TradeContext(DbContextOptions<TradeContext> options) : base(options) { }

        public DbSet<OMSTradeData> TradeData { get; set; }


        public bool CommitTrades(IEnumerable<OMSTradeData>trades)
        {
            TradeData.AddRange(trades);
            SaveChanges();

            return true;
        }

        //public Task<bool> CommitTrades(Stream trades)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public OMSTradeData GetData(int tradeId)
        //{
        //    throw new System.NotImplementedException();
        //}

    }
}
