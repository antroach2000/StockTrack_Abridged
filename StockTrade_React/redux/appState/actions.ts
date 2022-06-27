import { actionTypesAppstate } from './actions.interfaces';

export const SetAllCompaniesCountry = (payload: number) => (dispatch: any) => {
  return dispatch({
    type: actionTypesAppstate.SET_ALLCOMPANIES_COUNTRY,
    payload,
  });
};

export const SetAllCompaniesPageSize = (payload: number) => (dispatch: any) => {
  return dispatch({
    type: actionTypesAppstate.SET_ALLCOMPANIES_PAGE_SIZE,
    payload,
  });
};

export const SetAllCompaniesPageIndex =
  (payload: number) => (dispatch: any) => {
    return dispatch({
      type: actionTypesAppstate.SET_ALLCOMPANIES_PAGE_INDEX,
      payload,
    });
  };

export const SetToken = (payload: string) => (dispatch: any) => {
  return dispatch({
    type: actionTypesAppstate.SET_TOKEN,
    payload,
  });
};

export const setBalance = (payload: number) => (dispatch: any) => {
  return dispatch({
    type: actionTypesAppstate.SET_BALANCE,
    payload,
  });
};

export const updateBalance = (payload: number) => (dispatch: any) => {
  return dispatch({
    type: actionTypesAppstate.UPDATE_BALANCE,
    payload,
  });
};
export const addWatchList = (payload: number) => (dispatch: any) => {
  return dispatch({
    type: actionTypesAppstate.ADD_WATCHLIST,
    payload,
  });
};

export const clearWatchList = () => (dispatch: any) => {
  return dispatch({
    type: actionTypesAppstate.CLEAR_WATCHLIST,
  });
};

export const removeWatchList = (payload: number) => (dispatch: any) => {
  return dispatch({
    type: actionTypesAppstate.REMOVE_WATCHLIST,
    payload,
  });
};

export const addStockPurchase = (payload: number) => (dispatch: any) => {
  return dispatch({
    type: actionTypesAppstate.ADD_STOCK_PURCHASE,
    payload,
  });
};

export const clearStockPurchase = () => (dispatch: any) => {
  return dispatch({
    type: actionTypesAppstate.CLEAR_STOCK_PURCHASE,
  });
};

export const addDashboardStockPurchase =
  (payload: number) => (dispatch: any) => {
    return dispatch({
      type: actionTypesAppstate.ADD_DASHBOARD_STOCK_PURCHASE,
      payload,
    });
  };

export const clearDashboardStockPurchase = () => (dispatch: any) => {
  return dispatch({
    type: actionTypesAppstate.CLEAR_DASHBOARD_STOCK_PURCHASE,
  });
};
