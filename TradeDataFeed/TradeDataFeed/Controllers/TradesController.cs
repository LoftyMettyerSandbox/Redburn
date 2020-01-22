using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TradeDataFeed.Enums;
using TradeDataFeed.Interfaces;
using TradeDataFeed.Models;

namespace TradeDataFeed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradesController : ControllerBase //, ITradeDataService
    {

        private readonly ITradeDataContext _tradeContext;
        //private readonly ITradeDataService

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

        //[HttpGet("{id}")]
        //public ActionResult<OMSTradeData> Get(int id)
        //{
        //    //var data = _tradeDataService.GetData(id);
        //    //return data;
        //    return new OMSTradeData() { Identifier = "helloducky" };
        //}

        [HttpPost]
        public void Post([FromBody] object jsonData)
        {
            // got to be an object to we can programatically deal with malformed or garbage data.

            try {
                var _tradeDataService = new TradeDataService(_tradeContext);
                var tradeMessage = new OMSTradeDataMessage(jsonData.ToString());

                //                var result = _tradeDataService.CommitTrades(tradeMessage);

                _tradeDataService.AddTrade(tradeMessage);

                // tradeservices.validate

                // handle and send to message bin

            }
            catch {
            }

            //            var toTrades = new List<OMSTradeData>(dataStream);



          //  _tradeDataService.CommitTrades(dataStream);

        }

    }
}
