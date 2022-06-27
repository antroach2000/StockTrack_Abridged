using StockTrade.API.Extensions;

namespace StockTrade.API.Enums
{
    public enum Lookup : int
    {
		INCOME_FROM_SALARY=1,
		SAVING_FROM_INCOME = 2,
		SALE_OF_INVESTMENTS = 3,
		SALE_OF_PROPERTY = 4,
		GIFT = 5,
		INHERITANCE = 6,
		DIVORCE_SETTLEMENT = 7,
		OTHER = 8,
		DEBIT_CARD = 9,
		CREDIT_CARD = 10,
		MONEY_IN = 11,
		STOCK_BUY = 13,
		STOCK_SELL = 15,
		BUY_STOCK = 16,
		SELL_STOCK = 17,
		LESS_THAN = 18,
		GREATER_THAN = 19,
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
		NIKKEI = 10005
	}
}
