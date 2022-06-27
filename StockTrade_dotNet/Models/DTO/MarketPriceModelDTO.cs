using StockTrade.API.Enums;
using System;
using System.Collections.Generic;

namespace StockTrade.API.Models.DTO
{

    public class MarketPriceModelDTO
    {
        public double ChangeInPercent { get; set; }
        public double ChangePrice { get; set; }
        public DateTime CloseDate { get; set; }
        public double ClosePrice { get; set; }
        public double OpenPrice { get; set; }
        public double DayHighPrice { get; set; }
        public String Code { get; set; }
        public double DayLowPrice { get; set; }
        public Int64 Volume { get; set; }
        public String ExchangeTimezoneName { get; set; }
        public string CountryCurrencySymbol { get; set; }
        public double FiftyTwoWeekHigh { get; set; }
        public double FiftyTwoWeekHighChange { get; set; }
        public String AnalystRating { get; set; }
        public double FiftyTwoWeekHighChangePercent { get; set; }
        public double FiftyTwoWeekLow { get; set; }
        public double FiftyTwoWeekLowChange { get; set; }
        public double FiftyTwoWeekLowChangePercent { get; set; }
        public double MarketCap { get; set; }
        public double ForwardPE { get; set; }
        public double PriceEpsCurrentYear { get; set; }
        public double PriceToBook { get; set; }
    }
    public class MarketPriceListDTO
    {
        public List<MarketPriceModelDTO> shareDataHistory { get; set; }
    }
}
