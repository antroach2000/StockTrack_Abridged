using StockTrade.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrade.API.Repositories.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<int?> RemoveAsync(Guid portfolioId);
        Task<PortfolioModel> AddAsync(PortfolioModel portfolioModel);
        Task<PortfolioModel> GetAsync(Guid portfolioId);
        Task<bool> ExistsAsync(PortfolioModel portfolioModel);
    }

}