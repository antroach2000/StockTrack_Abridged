using StockTrade.API.Enums;
using System;

namespace StockTrade.API.Models.DTO
{
    public class PortfolioModelDTO
    {
        public Guid PortfolioId { get; set; }
        public STOCKEXCHANGE StockExchangeId { get; set; }
        public string CountryFlagPath { get; set; }
        public string Country { get; set; }
        public string UserId { get; set; }
        public double Paid { get; set; }
        public string CountryCurrencySymbol { get; set; }
        public int CompanyCount { get; set; }
        public int IndustryGroupId { get; set; }
        public string IndustryDescription { get; set; }
        public string Name { get; set; }
    }
}