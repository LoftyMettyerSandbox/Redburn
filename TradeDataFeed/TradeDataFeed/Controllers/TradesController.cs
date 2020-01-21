using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TradeDataFeed.Interfaces;
using TradeDataFeed.Models;

namespace TradeDataFeed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradesController : ControllerBase
    {

        private readonly ITradeDataService _tradeDataService;

        public TradesController(ITradeDataService tradeDataService)
        {
            _tradeDataService = tradeDataService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //throw new NotImplementedException();
            return null;
        }

        [HttpGet("{id}")]
        public ActionResult<OMSTradeData> Get(int id)
        {
            var data = _tradeDataService.GetData(id);
            return data;
        }

    }
}
