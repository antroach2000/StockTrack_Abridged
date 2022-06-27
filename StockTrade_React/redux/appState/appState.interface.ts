export interface AppState {
  balance: number | null;
  newStockPurchase: number | null;
  newWatchList: number | null;
  newDashboard: number | null;
  allCompaniesPageIndex: number | null;
  allCompaniesCountry: number | null;
  allCompaniesPageSize: number | null;
  token: string;
}
