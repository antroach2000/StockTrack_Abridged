import { Action, actionTypesAppstate } from './actions.interfaces';
import { AppState } from './appState.interface';

export const initialState: AppState = {
  balance: 0,
  newStockPurchase: 0,
  newWatchList: 0,
  newDashboard: 0,
  allCompaniesPageIndex: 0,
  allCompaniesCountry: 0,
  allCompaniesPageSize: 50,
  token: '',
};

const appReducer = (state = initialState, action: Action): AppState => {
  switch (action.type) {
    case actionTypesAppstate.SET_ALLCOMPANIES_PAGE_INDEX:
      return {
        ...state,
        allCompaniesPageIndex: action.payload,
      };

    case actionTypesAppstate.SET_ALLCOMPANIES_COUNTRY:
      return {
        ...state,
        allCompaniesCountry: action.payload,
      };

    case actionTypesAppstate.SET_ALLCOMPANIES_PAGE_SIZE:
      return {
        ...state,
        allCompaniesPageSize: action.payload,
      };

    case actionTypesAppstate.SET_TOKEN:
      return {
        ...state,
        token: action.payload,
      };

    case actionTypesAppstate.SET_BALANCE:
      return {
        ...state,
        balance: action.payload,
      };
    case actionTypesAppstate.UPDATE_BALANCE:
      const newstate = {
        ...state,
        balance:
          state.balance === null
            ? action.payload
            : state.balance + action.payload,
      };
      return newstate;

    case actionTypesAppstate.ADD_STOCK_PURCHASE:
      return {
        ...state,
        newStockPurchase:
          state.newStockPurchase === null
            ? action.payload
            : state.newStockPurchase + action.payload,
      };

    case actionTypesAppstate.CLEAR_STOCK_PURCHASE:
      return {
        ...state,
        newStockPurchase: 0,
      };

    case actionTypesAppstate.ADD_WATCHLIST:
      return {
        ...state,
        newWatchList:
          state.newWatchList === null
            ? action.payload
            : state.newWatchList + action.payload,
      };

    case actionTypesAppstate.REMOVE_WATCHLIST:
      if (state.newWatchList === 0) {
        return {
          ...state,
          newWatchList: 0,
        };
      }

      return {
        ...state,
        newWatchList:
          state.newWatchList === null
            ? action.payload
            : state.newWatchList - action.payload,
      };

    case actionTypesAppstate.CLEAR_WATCHLIST:
      return {
        ...state,
        newWatchList: 0,
      };

    case actionTypesAppstate.ADD_DASHBOARD_STOCK_PURCHASE:
      return {
        ...state,
        newDashboard:
          state.newDashboard === null
            ? action.payload
            : state.newDashboard + action.payload,
      };

    case actionTypesAppstate.CLEAR_DASHBOARD_STOCK_PURCHASE:
      return {
        ...state,
        newDashboard: 0,
      };

    default:
      return state;
  }
};

export default appReducer;
