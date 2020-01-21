using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TradeDataFeed.Interfaces;

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
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var data = _tradeDataService.GetData();
            return data;
        }

    }
}
