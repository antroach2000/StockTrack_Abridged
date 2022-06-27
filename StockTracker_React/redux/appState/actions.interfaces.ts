export enum actionTypesAppstate {
  UPDATE_BALANCE = 'UPDATE_BALANCE',
  SET_BALANCE = 'SET_BALANCE',
  ADD_STOCK_PURCHASE = 'ADD_STOCK_PURCHASE',
  CLEAR_STOCK_PURCHASE = 'CLEAR_STOCK_PURCHASE',
  ADD_WATCHLIST = 'ADD_WATCHLIST',
  REMOVE_WATCHLIST = 'REMOVE_WATCHLIST',
  CLEAR_WATCHLIST = 'CLEAR_WATCHLIST',
  ADD_DASHBOARD_STOCK_PURCHASE = 'ADD_DASHBOARD_STOCK_PURCHASE',
  CLEAR_DASHBOARD_STOCK_PURCHASE = 'CLEAR_DASHBOARD_STOCK_PURCHASE',
  SET_ALLCOMPANIES_PAGE_INDEX = 'SET_ALLCOMPANIES_PAGE_INDEX',
  SET_ALLCOMPANIES_COUNTRY = 'SET_ALLCOMPANIES_COUNTRY',
  SET_ALLCOMPANIES_PAGE_SIZE = 'SET_ALLCOMPANIES_PAGE_SIZE',
  SET_TOKEN = 'SET_TOKEN',
}

export type Action =
  | UpdateBalance
  | SetBalance
  | AddStockPurchase
  | ClearStockPurchase
  | AddWatchList
  | RemoveWatchList
  | ClearWatchList
  | AddDashboardStockPurchase
  | ClearDashboardStockPurchase
  | SetAllCompaniesPageIndex
  | SetAllCompaniesCountry
  | SetAllCompaniesPageSize
  | SetToken;

export interface SetAllCompaniesCountry {
  type: actionTypesAppstate.SET_ALLCOMPANIES_COUNTRY;
  payload: number;
}

export interface SetAllCompaniesPageSize {
  type: actionTypesAppstate.SET_ALLCOMPANIES_PAGE_SIZE;
  payload: number;
}

export interface SetAllCompaniesPageIndex {
  type: actionTypesAppstate.SET_ALLCOMPANIES_PAGE_INDEX;
  payload: number;
}

export interface SetToken {
  type: actionTypesAppstate.SET_TOKEN;
  payload: string;
}

export interface SetBalance {
  type: actionTypesAppstate.SET_BALANCE;
  payload: number;
}
export interface UpdateBalance {
  type: actionTypesAppstate.UPDATE_BALANCE;
  payload: number;
}

export interface AddStockPurchase {
  type: actionTypesAppstate.ADD_STOCK_PURCHASE;
  payload: number;
}

export interface ClearStockPurchase {
  type: actionTypesAppstate.CLEAR_STOCK_PURCHASE;
}

export interface AddWatchList {
  type: actionTypesAppstate.ADD_WATCHLIST;
  payload: number;
}

export interface RemoveWatchList {
  type: actionTypesAppstate.REMOVE_WATCHLIST;
  payload: number;
}

export interface ClearWatchList {
  type: actionTypesAppstate.CLEAR_WATCHLIST;
}

export interface AddDashboardStockPurchase {
  type: actionTypesAppstate.ADD_DASHBOARD_STOCK_PURCHASE;
  payload: number;
}

export interface ClearDashboardStockPurchase {
  type: actionTypesAppstate.CLEAR_DASHBOARD_STOCK_PURCHASE;
}
