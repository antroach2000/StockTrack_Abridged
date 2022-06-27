using StockTrade.API.Services.Interfaces;
using StockTrade.API.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockTrade.API.Models;

namespace StockTrade.API.Services
{
    public class IndustryGroupService : IIndustryGroupService
    {
        private readonly IIndustryGroupRepository _industryGroupRepository;

        public IndustryGroupService(IIndustryGroupRepository industryGroupRepository)
        {
            _industryGroupRepository = industryGroupRepository;            
        }
        public async Task<IndustryGroupModel> GetIndustryDescriptionAsync(int industryGroupId)
        {
            return await _industryGroupRepository.GetIndustryDescriptionAsync(industryGroupId);
        }
        public async Task<IEnumerable<IndustryGroupModel>> GetAllAsync()
        {
            var records = await _industryGroupRepository.GetAllAsync();

            return records;
        }

    }
}
