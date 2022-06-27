using StockTrade.API.Models;
using StockTrade.API.Services.Interfaces;
using System;
using System.Threading.Tasks;
using StockTrade.API.Models.DTO;
using StockTrade.API.Repositories.Interfaces;

namespace StockTrade.API.Services
{
    public class PortfolioService: IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IIndustryGroupService _industryGroupService;

        public PortfolioService(IPortfolioRepository portfolioRepository, IIndustryGroupService industryGroupService)
        {
            _portfolioRepository = portfolioRepository;
            _industryGroupService = industryGroupService;
        }
        public async Task<int?> RemoveAsync(Guid portfolioId)
        {
            if (portfolioId == Guid.Empty)
                throw new ArgumentException($"{nameof(PortfolioService)}->RemoveAsync() portfolioId:{portfolioId} is null or empty");

            return await _portfolioRepository.RemoveAsync(portfolioId);
        }
        public async  Task<PortfolioModelDTO> AddAsync(PortfolioModel portfolioModel)
        {
            if (portfolioModel == null)
                throw new ArgumentException($"{nameof(PortfolioService)}->AddAsync() portfolioModel:{portfolioModel} is null or empty");

            if (portfolioModel.IndustryGroupId <= 0 || portfolioModel.IndustryGroupId > GlobalConstants.MAX_INDUSTRY_GROUPID)
                throw new ArgumentException($"{nameof(PortfolioService)}->AddAsync() industryGroupId = {portfolioModel.IndustryGroupId} must be >0 and <={GlobalConstants.MAX_INDUSTRY_GROUPID}");

            var record = await _portfolioRepository.AddAsync(portfolioModel);

            if (record == null)
                return null;

            var industryGroup = await _industryGroupService.GetIndustryDescriptionAsync(portfolioModel.IndustryGroupId);
            var portfolioModelDTO = new PortfolioModelDTO()
            {
                PortfolioId = (Guid)record.PortfolioId,
                StockExchangeId = record.StockExchangeId,
                UserId = record.UserId,
                IndustryGroupId = record.IndustryGroupId,
                IndustryDescription = industryGroup.IndustryDescription,
                Name = record.Name,
            };

            return portfolioModelDTO;
        }
        public async Task<PortfolioModelDTO> GetAsync(Guid portfolioId)
        {
            if (portfolioId == Guid.Empty)
                throw new ArgumentException($"{nameof(PortfolioService)}->GetAsync() portfolioId:{portfolioId} is null or empty");

            var record = await _portfolioRepository.GetAsync(portfolioId);

            if (record == null)
                return null;

            var industryGroup = await _industryGroupService.GetIndustryDescriptionAsync(record.IndustryGroupId);
            var portfolioModelDTO = new PortfolioModelDTO()
            {
                PortfolioId = (Guid)record.PortfolioId,
                StockExchangeId = record.StockExchangeId,
                UserId = record.UserId,
                IndustryGroupId = record.IndustryGroupId,
                IndustryDescription = industryGroup.IndustryDescription,
                Name = record.Name,
            };

            return portfolioModelDTO;
        }
        public async Task<APIResponse> ExistsAsync(PortfolioModel portfolioModel)
        {
            if (portfolioModel == null)
                throw new ArgumentException($"{nameof(PortfolioService)}->ExistsAsync() portfolioModel null or empty");

            var portfolioItem = await _portfolioRepository.ExistsAsync(portfolioModel);

            if (portfolioItem)
            {
                return new APIResponse { ErrorMessage = $"Portfolio {portfolioModel.PortfolioId} Name:{portfolioModel.Name} IndustryGroupId:{portfolioModel.IndustryGroupId} UserId:{portfolioModel.UserId} already exist in your portfolio list", Success = false, HttpStatusCode = 409 };
            }

            return null;
        }
    }
}
