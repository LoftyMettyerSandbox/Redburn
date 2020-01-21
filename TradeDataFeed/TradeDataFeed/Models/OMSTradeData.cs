using TradeDataFeed.Enums;

namespace TradeDataFeed.Models
{
    // Class properties borrowed from https://www.investopedia.com/terms/o/oms.asp
    // They've got two properties called order type - are they deliberately trying to confuse me?
    // may or may not align with real world examples

    public class OMSTradeData
    {
        public string Identifier { get; set; }
        public OrderType OrderType { get; set; }
        public int OrderSize { get; set; }
        public OrderSubType OrderSubType { get; set; }
        public string Instruction { get; set; }
        public OrderTransmissionType OrderTransmissionType { get; set; }

    }
}
