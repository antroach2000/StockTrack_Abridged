import { v4 as uuidv4 } from 'uuid';
import IPortfolio from '@models/portfolio.model';
import ApiResponse from '@models/apiResponse.model';
import { BaseHttpDataService } from './BaseHttpDataService';

export default class PortfolioService extends BaseHttpDataService {
  constructor(cookie?: string) {
    super(process.env.NEXT_PUBLIC_STOCKTRADER_BASE_URL_PATH as string, cookie);
  }

  updatePortfolio = async (
    portfolio: IPortfolio,
  ): Promise<ApiResponse<IPortfolio>> => {
    if (!portfolio) throw new Error('updatePortfolio=>Invalid param portfolio');

    const payload = {
      name: portfolio.name,
      portfolioId: portfolio.portfolioId,
      stockExchangeId: portfolio.stockExchangeId,
      industryGroupId: portfolio.industryGroupId,
    };

    const response = await this.put(`portfolio/update`, payload);

    return response;
  };

  getPortfolioList = async (): Promise<ApiResponse<IPortfolio[]>> => {
    const response = await this.get(`portfolio/list`);

    return response;
  };

  addPortfolio = async (
    portfolio: IPortfolio,
  ): Promise<ApiResponse<IPortfolio>> => {
    if (!portfolio) throw new Error('addPortfolio=>Invalid param portfolio');

    const payload = {
      portfolioId: uuidv4(),
      stockExchangeId: portfolio.stockExchangeId,
      industryGroupId: portfolio.industryGroupId,
      name: portfolio.name,
    };

    const response = await this.post(`portfolio/add`, payload);

    return response.data;
  };

  deletePortfolio = async (portfolioId: string): Promise<any> => {
    if (!portfolioId)
      throw new Error('deletePortfolio=>Invalid param portfolioId');

    const response = await this.delete(`portfolio/remove/${portfolioId}`);

    return response;
  };
}
