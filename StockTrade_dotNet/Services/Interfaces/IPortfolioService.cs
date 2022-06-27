using StockTrade.API.Models;
using StockTrade.API.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrade.API.Services.Interfaces
{
    public interface IPortfolioService
    {
        Task<int?> RemoveAsync(Guid portfolioId);
        Task<PortfolioModelDTO> AddAsync(PortfolioModel portfolioModel);
        Task<PortfolioModelDTO> GetAsync(Guid portfolioId);
        Task<APIResponse> ExistsAsync(PortfolioModel portfolioModel);
    }
}