import React, { useEffect }  from 'react';
// nextjs
import Head from 'next/head';
import { GetServerSidePropsContext, GetServerSidePropsResult } from 'next';
import { getSession } from 'next-auth/client';
// next-auth
// components
// models
import ICompany from '@core/models/company.model';
import IIndustryGroup from '@core/models/IndustryGroup.model.';
import IStockExchangeModel from '@core/models/StockExchange.model';
import IUserAccount from '@core/models/UserAccount.model';
import IServerSideLoadAllPage from '@core/models/ServerSideLoadAllPage.model';
import ApiResponse from '@core/models/apiResponse.model';
// services
import ServerSideInitialPageLoadService from '@core/services/web-api/ServerSideInitialPageLoadService';
import { useDispatch } from 'react-redux';
import { useLookupList, LookupListActionTypes } from 'store/lookupList-context';
import { actionTypesAppstate } from '@redux/appState/actions.interfaces';

type HomePageProps = {
  companyList: ICompany[];
  cryptoList: ICompany[];
  stockExchangeList: IStockExchangeModel[];
  industryGroupList: IIndustryGroup[];
  userAccount: IUserAccount;
  token: string;
};

const Home: React.FC<HomePageProps> = ({
  companyList,
  cryptoList,
  stockExchangeList,
  industryGroupList,
  userAccount,
  token,
}) => {
  const appLookupList = useLookupList();
  const dispatch = useDispatch();

  useEffect(() => {
    if (companyList)
      appLookupList.dispatch({
        type: LookupListActionTypes.LOAD_COMPANIES,
        payload: companyList,
      });

    if (cryptoList)
      appLookupList.dispatch({
        type: LookupListActionTypes.LOAD_CRYPTO,
        payload: cryptoList,
      });

    if (industryGroupList)
      appLookupList.dispatch({
        type: LookupListActionTypes.LOAD_INDUSTRY_GROUPS,
        payload: industryGroupList,
      });

    if (stockExchangeList)
      appLookupList.dispatch({
        type: LookupListActionTypes.LOAD_STOCKEXCHANGES,
        payload: stockExchangeList,
      });

    if (token)
      dispatch({
        type: actionTypesAppstate.SET_TOKEN,
        payload: token,
      });

    if (userAccount)
      dispatch({
        type: actionTypesAppstate.SET_BALANCE,
        payload: userAccount.balance,
      });
  }, []);

  return (
    <>
      <Head>
        <meta
          name='viewport'
          content='width=device-width, initial-scale=1.0'></meta>
        <title>Stocktracker trader</title>
        <link rel='icon' href='/favicon.ico' />
      </Head>
    </>
  );
};

export async function getServerSideProps(
  context: GetServerSidePropsContext,
): Promise<GetServerSidePropsResult<HomePageProps>> {
  const { res, req, query } = context;
  const session = await getSession(context);

  if (!session)
    return {
      redirect: {
        destination: '/auth',
        permanent: false,
      },
    };

  var token = req.cookies.token || '';

  const serverSideInitialPageLoadService = new ServerSideInitialPageLoadService(
    token,
  );
  
  const response: ApiResponse<IServerSideLoadAllPage> =
    await serverSideInitialPageLoadService.getAllInitialLoadCompanies();

  return {
    props: {
      companyList: response.data.companyList,
      cryptoList: response.data.cryptoList,
      stockExchangeList: response.data.stockExchangeList,
      industryGroupList: response.data.industryGroupList,
      userAccount: response.data.userAccount,
      token: token,
    },
  };
}

export default Home;
