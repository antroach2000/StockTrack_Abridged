import ApiResponse from '@models/apiResponse.model';
import IIndustryGroup from '@core/models/IndustryGroup.model.';
import { BaseHttpDataService } from './BaseHttpDataService';

export default class IndustryGroupService extends BaseHttpDataService {
  constructor(cookie?: string) {
    super(process.env.NEXT_PUBLIC_STOCKTRADER_BASE_URL_PATH as string, cookie);
  }

  getAll = async (): Promise<ApiResponse<IIndustryGroup[]>> => {
    const response = await this.get(`industrygroup`);

    return response;
  };
}
