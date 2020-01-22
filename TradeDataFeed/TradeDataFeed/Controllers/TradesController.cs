using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TradeDataFeed.Interfaces;
using TradeDataFeed.Models;

namespace TradeDataFeed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradesController : ControllerBase, ITradeDataService
    {

        private readonly ITradeDataContext _tradeContext;

        public TradesController(ITradeDataContext tradeContext)
        {
            _tradeContext = tradeContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OMSTradeData>> Get()
        {
            //throw new NotImplementedException();
            return new List<OMSTradeData>(); // OMSTradeData() { Identifier = "hellodonald" };
        }

        [HttpGet("{id}")]
        public ActionResult<OMSTradeData> Get(int id)
        {
            //var data = _tradeDataService.GetData(id);
            //return data;
            return new OMSTradeData() { Identifier = "helloducky" };
        }

        [HttpPost]
        public void Post([FromBody] object jsonData)
        {

            // got to be an object to we can programatically deal with malformed or garbage data.

            //var toTrades = Convert.ChangeType(dataStream, typeof(List<OMSTradeData>));
            var tradeData = JsonConvert.DeserializeObject<IList<OMSTradeData>>(jsonData.ToString());


            //            var toTrades = new List<OMSTradeData>(dataStream);

            var _tradeDataService = new TradeDataService(_tradeContext);
          //  _tradeDataService.CommitTrades(dataStream);
            //_tradeDataService.CommitTrades(value);
        }

    }
}
