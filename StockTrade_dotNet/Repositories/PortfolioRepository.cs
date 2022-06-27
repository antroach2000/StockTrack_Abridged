using Dapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StockTrade.API.Models;
using StockTrade.API.Repositories.Base;
using StockTrade.API.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace StockTrade.API.Repositories
{
    public class PortfolioRepository : BaseRepository, IPortfolioRepository
    {
        public PortfolioRepository(ILogger<PortfolioRepository> logger, IOptions<AppOptions> settings) : base(logger, settings)
        {

        }
        public async Task<int?> RemoveAsync(Guid PortfolioId)
        {
            var param = new DynamicParameters();

            param.Add("@PortfolioId", PortfolioId);

            var sql = "EXEC dbo.RemovePortfolio @PortfolioId = @PortfolioId";

            int? recordsAffected = await _dbConnection.ExecuteAsync(sql, param);

            return recordsAffected == 0 ? null : recordsAffected;
        }
        public async Task<PortfolioModel> AddAsync(PortfolioModel portfolioModel)
        {
            var param = new DynamicParameters();
            
            param.Add("@PortfolioId", portfolioModel.PortfolioId);
            param.Add("@StockExchangeId", portfolioModel.StockExchangeId);
            param.Add("@UserId", portfolioModel.UserId);
            param.Add("@IndustryGroupId", portfolioModel.IndustryGroupId);
            param.Add("@Name", portfolioModel.Name);

            var sql = "EXEC	dbo.InsertPortfolio @PortfolioId = @PortfolioId, @StockExchangeId = @StockExchangeId, @UserId = @UserId, @IndustryGroupId = @IndustryGroupId, @Name = @Name";

            int? recordsAffected = await _dbConnection.ExecuteAsync(sql, param);

            return recordsAffected == 0 ? null : new PortfolioModel() { PortfolioId = portfolioModel.PortfolioId, StockExchangeId = portfolioModel.StockExchangeId, UserId = portfolioModel.UserId, IndustryGroupId = portfolioModel.IndustryGroupId, Name = portfolioModel.Name };
        }
        public async Task<bool> ExistsAsync(PortfolioModel portfolioModel)
        {
            var param = new DynamicParameters();

            param.Add("@PortfolioId", portfolioModel.PortfolioId);

            var sql = "EXEC	dbo.PortfolioExists @PortfolioId = @PortfolioId";

            var recordsAffected = await _dbConnection.ExecuteScalarAsync<int>(sql, param);

            return recordsAffected > 0 ? true : false;
        }
        public async Task<PortfolioModel> GetAsync(Guid portfolioId)
        {
            var param = new DynamicParameters();

            param.Add("@PortfolioId", portfolioId);

            var sql = "EXEC	dbo.GetPortfolio @PortfolioId = @PortfolioId";

            var record = await _dbConnection.QuerySingleOrDefaultAsync<PortfolioModel>(sql, param);

            return record;
        }
    }
}
    