export const LOOKUP_TYPE_INCOME_SOURCE = 1;
export const LOOKUP_TYPE_PAYMENT_METHOD = 2;
export const LOOKUP_TYPE_PAYMENT_TYPE = 3;
export const LOOKUP_TYPE_TRANSACTION_TYPE = 4;
export const LOOKUP_TYPE_ORDER_TYPE = 5;
export const LOOKUP_TYPE_COMPARISON_TYPE = 6;
export const LOOKUP_TYPE_STOCK_EXCHANGES = 7;

export const LOOKUP_ID_INCOME_FROM_SALARY = 1;
export const LOOKUP_ID_SAVING_FROM_INCOME = 2;
export const LOOKUP_ID_SALE_OF_INVESTMENTS = 3;
export const LOOKUP_ID_SALE_OF_PROPERTY = 4;
export const LOOKUP_ID_GIFT = 5;
export const LOOKUP_ID_INHERITANCE = 6;
export const LOOKUP_ID_DIVORCE_SETTLEMENT = 7;
export const LOOKUP_ID_OTHER = 8;
export const LOOKUP_ID_DEBIT_CARD = 9;
export const LOOKUP_ID_CREDIT_CARD = 10;
export const LOOKUP_ID_MONEY_IN = 11;
export const LOOKUP_ID_STOCK_BUY = 13;
export const LOOKUP_ID_STOCK_SELL = 15;
export const LOOKUP_ID_BUY_STOCK = 16;
export const LOOKUP_ID_SELL_STOCK = 17;
export const LOOKUP_ID_LESS_THAN = 18;
export const LOOKUP_ID_GREATER_THAN = 19;
export const COUNTUP_MARKET_OPEN = 1.25;
export const COUNTUP_PREVIOUS_CLOSE = 1.25;
export const COUNTUP_FIFTY_TWO_WEEK_LOW = 1.25;
export const COUNTUP_FIFTY_TWO_WEEK_HIGH = 1.25;
export const COUNTUP_VOLUME = 1.25;
export const COUNTUP_DAY_LOW = 1.25;
export const COUNTUP_DAY_HIGH = 1.25;
export const COUNTUP_FORWARD_PE = 1.25;
export const COUNTUP_MARKET_CHANGE_PERCENT = 1.25;
export const COUNTUP_MARKET_CAP = 1.25;
export const COUNTUP_PRICE = 0.75;
export const COUNTUP_QTY = 0.75;
export const COUNTUP_TOTAL_VALUE = 0.75;
export const COUNTUP_PURCHASED_STOCKS = 0.75;

export enum Exchange_Name {
  ASX = 10000,
  DOW_JONES = 10002,
  FTSE_100 = 10003,
  NASDAQ = 10004,
  NIKKEI = 10005,
  CRYPTO = 20000,
}

export enum Exchange_Type {
  StockExchange = 1,
  CryptoCurrency = 2,
  ExchangeRate = 3,
  Gold = 10,
}
