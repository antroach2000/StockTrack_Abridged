using StockTrade.API.Extensions;

namespace StockTrade.API.Enums
{
    public enum COUNTRYCURRENCY : int
    {
        [StringValue("AUD")]
        AUD = 1,
        [StringValue("GBP")]
        GBP = 2,
        [StringValue("USD")]
        USD = 3,
        [StringValue("EUR")]
        EUR = 4,
        [StringValue("JPY")]
        JPY = 10,
    }
}
