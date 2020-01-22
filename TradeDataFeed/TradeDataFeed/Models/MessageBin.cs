using System;
using System.ComponentModel.DataAnnotations.Schema;
using TradeDataFeed.Enums;

namespace TradeDataFeed.Models
{
    public class MessageBin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string Message { get; set; }
        public MessageValidityType ValidityType { get; set; }
        public int TradesInMessage { get; set; }

    }
}
