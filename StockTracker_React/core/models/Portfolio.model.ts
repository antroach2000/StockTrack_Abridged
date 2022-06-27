export default interface IPortfolio {
  portfolioId?: string;
  stockExchangeId?: number;
  countryFlagPath?: string;
  paid?: number;
  companyCount?: number;
  country?: string;
  countryCurrencySymbol?: string;
  industryGroupId?: number;
  userId?: string;
  industryDescription?: string;
  name: string;
}
