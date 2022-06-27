using System;

namespace StockTrade.API.Models.ASX
{
    public class MarketPriceASX
    {
        public string change_in_percent { get; set; }
        public double change_price { get; set; }
        public DateTime close_date { get; set; }
        public double close_price { get; set; }
        public String code { get; set; }
        public double day_high_price { get; set; }
        public double day_low_price { get; set; }
        public Int64 volume { get; set; }
    }
}
