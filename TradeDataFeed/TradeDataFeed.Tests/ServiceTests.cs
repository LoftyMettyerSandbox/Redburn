using Microsoft.EntityFrameworkCore;
using TradeDataFeed.Contexts;
using TradeDataFeed.Interfaces;
using TradeDataFeed.Models;
using TradeDataFeed.Streams;
using TradeDataFeed.Tests.MockData;
using Xunit;

namespace TradeDataFeed.Tests
{

    public class ServiceTests
    {

        //private MockTradeContext _tradeContext = new MockTradeContext();
        private ITradeDataStream _tradeDataStream = new MockTradeDataStream();
        private IMessageQueue messageQueue = new MockMessageQueue();

        //ServiceTests() {
        //    // do initialisation here!


        //}

        //[Fact]
        //public void TradeCommitsValidStream()
        //{

        //    var tradeService = new TradeDataService(_tradeContext);
        //    var tradeData = _tradeContext.GetTradeStream();

        //    var result = tradeService.CommitTrades(tradeData);
        //    //Assert .IsType<OMSTradeData>(data.Value);
        //    Assert.True(result);
        //    //Assert.IsType<OMSTradeData>(data.Value);
        //}

        [Fact]
        public void BigFatDoEverything()
        {

            var optionsBuilder = new DbContextOptionsBuilder<TradeContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=Redburn_Lofty1;Trusted_Connection = True;");

            var liveContext = new TradeContext(optionsBuilder.Options);
            //liveContext.Database.Migrate();
            liveContext.Database.EnsureCreated();   // shouldnt be necessary but for some reason db is not getting generated on savechanges. Investigate when given time.

            var tradeService = new TradeDataService(liveContext); //, messageQueue);

            var tradeStream = _tradeDataStream.GetTradeStream();
            var tradeMessage = new OMSTradeDataMessage(tradeStream);

            var result = tradeService.AddTrade(tradeMessage);

            Assert.True(result);

        }

    }
}