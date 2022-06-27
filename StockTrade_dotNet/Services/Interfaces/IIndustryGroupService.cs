using StockTrade.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrade.API.Services.Interfaces
{
    public interface IIndustryGroupService
    {
        Task<IndustryGroupModel> GetIndustryDescriptionAsync(int industryGroupId);
        Task<IEnumerable<IndustryGroupModel>> GetAllAsync();
    }
}
