using StockTrade.API.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace StockTrade.API.Models
{
    public class PortfolioModel
    {
        [Required(ErrorMessage = "PortfolioId is required")]
        public Guid? PortfolioId { get; set; }
        
        [Required(ErrorMessage = "StockExchangeId is required")]
        [Range((double)STOCKEXCHANGE.ASX, (double)STOCKEXCHANGE.NIKKEI)]
        public STOCKEXCHANGE StockExchangeId { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        [StringLength(64, MinimumLength = 7)]
        public string UserId { get;  set; }
        
        [Required(ErrorMessage = "IndustryGroupId is required")]
        [Range(1,GlobalConstants.MAX_INDUSTRY_GROUPID)]
        public int IndustryGroupId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get;  set; }
    }
}