using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using StockTrade.API.Models;
using Microsoft.Extensions.Options;

namespace StockTrade.API.Repositories.Base
{
    public abstract class BaseRepository : IDisposable
    {
        public IDbConnection _dbConnection;
        public ILogger _logger;
        public BaseRepository(ILogger logger, IOptions<AppOptions> settings)
        {
            _logger = logger;
            _dbConnection = new  SqlConnection(settings.Value.DbConnection);
        }

        public void Dispose()
        {
            _dbConnection.Dispose();
        }
    }
}
