using StockTrade.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace StockTrade.API.Repositories.Interfaces
{
    public interface IIndustryGroupRepository : IDisposable
    {
        Task<IndustryGroupModel> GetIndustryDescriptionAsync(int industryGroupId);
        Task<IEnumerable<IndustryGroupModel>> GetAllAsync();
    }
}
