using System;
using System.Threading.Tasks;
using Dapper;
using StockTrade.API.Repositories.Interfaces;
using StockTrade.API.Models;
using StockTrade.API.Repositories.Base;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace StockTrade.API.Repositories
{
    public class IndustryGroupRepository : BaseRepository, IIndustryGroupRepository
    {
        public IndustryGroupRepository(ILogger<IndustryGroupRepository> logger, IOptions<AppOptions> settings) : base(logger, settings)
        {
        }
        public async Task<IndustryGroupModel> GetIndustryDescriptionAsync(int industryGroupId)
        {
            var param = new DynamicParameters();

            param.Add("@IndustryGroupId", industryGroupId);

            var sql = "EXEC	dbo.GetIndustryDescription @IndustryGroupId = @IndustryGroupId";

            var record = await _dbConnection.QuerySingleOrDefaultAsync<IndustryGroupModel>(sql, param);

            return record;
        }
        public async Task<IEnumerable<IndustryGroupModel>> GetAllAsync()
        {
            var sql = "EXEC	dbo.GetIndustryGroup";

            var records = await _dbConnection.QueryAsync<IndustryGroupModel>(sql);

            return records;
        }
    }
}

