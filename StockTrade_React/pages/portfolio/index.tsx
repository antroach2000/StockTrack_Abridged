import React from 'react';
// nextjs
// next-auth
import { getSession } from 'next-auth/client';
// components
// container
import PortfolioContainer from '@containers/Portfolio/PortfolioContainer';
// models
import IPortfolio from '@models/portfolio.model';
// services
import PortfolioService from '@services/web-api/Portfolio';
import IndustryGroup from '@core/models/IndustryGroup.model.';

type PortfolioPageProps = {
  portfolioData: IPortfolio[];
  industryGroupData: IndustryGroup[];
};

const PortfolioPage: React.FC<PortfolioPageProps> = ({ portfolioData }) => {
  return (
    <>
      <PortfolioContainer portfolioData={portfolioData} />
    </>
  );
};

export async function getServerSideProps(context: any) {
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

  const portfolioService = new PortfolioService(token);
  const response = await portfolioService.getPortfolioList();

  return {
    props: {
      portfolioData: response.data,
    },
  };
}

export default PortfolioPage;
