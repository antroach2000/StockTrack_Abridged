using StockTrade.API.Extensions;

namespace StockTrade.API.Enums
{
    public enum STOCKEXCHANGE:int
    {
		[StringValue("AORD")]
		ASX = 10000,
		[StringValue("AXJO")]
		ASX200 = 10001,
		[StringValue("DJI")]
		DOW_JONES = 10002,
		[StringValue("FTSE")]
		FTSE_100 = 10003,
		[StringValue("IXIC")]
		NASDAQ = 10004,
		[StringValue("N225")]
		NIKKEI = 10005,
		CRYPTO = 20000,
		GOLD = 20001,
		EXCHANGE_RATE_EUR = 20002,
		EXCHANGE_RATE_GBP = 20003,
		EXCHANGE_RATE_USD = 20007
	}
}
