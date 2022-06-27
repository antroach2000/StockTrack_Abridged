using StockTrade.API.Models;
using StockTrade.API.Models.DTO;

namespace StockTrade.Tests.TestData
{
    public static class NewPortfolioTestData
    {
        public static PortfolioModelDTO PortfolioDTO
        {
            get
            {
                return new PortfolioModelDTO
                {
                    PortfolioId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa1"),
                    CompanyCount = 1,
                    Country = "Australia",
                    CountryCurrencySymbol = "A$",
                    CountryFlagPath = "c:\\flags",
                    IndustryDescription = "Technology Hardware & Equipment",
                    IndustryGroupId = 28,
                    Name = "Technology",
                    Paid = 0,
                    StockExchangeId = API.Enums.STOCKEXCHANGE.ASX,
                    UserId = "antroach2000@gmail.com"
                };
            }
        }
        public static PortfolioModel Portfolio
        {
            get
            {
                return new PortfolioModel
                {
                    PortfolioId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa1"),
                    IndustryGroupId = 28,
                    Name = "Technology",
                    StockExchangeId = API.Enums.STOCKEXCHANGE.ASX,
                    UserId = "antroach2000@gmail.com"
                };
            }
        }
        public static PortfolioModel InvalidIndustryGroupId
        {
            get
            {
                return new PortfolioModel
                {
                    PortfolioId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa1"),
                    IndustryGroupId = 1000,
                    Name = "Technology",
                    StockExchangeId = API.Enums.STOCKEXCHANGE.ASX,
                    UserId = "antroach2000@gmail.com"
                };
            }
        }
        public static PortfolioModel? NullPortfolioModel
        {
            get
            {
                return null;
            }
        }
        public static PortfolioModel InvalidIndustryGroupIdZero
        {
            get
            {
                return new PortfolioModel
                {
                    PortfolioId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa1"),
                    IndustryGroupId = 0,
                    Name = "Technology",
                    StockExchangeId = API.Enums.STOCKEXCHANGE.ASX,
                    UserId = "antroach2000@gmail.com"
                };
            }
        }
        public static PortfolioModelDTO? NullPortfolioModelDTO
        {
            get
            {
                return null;
            }
        }
    }
}
