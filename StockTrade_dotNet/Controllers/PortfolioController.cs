using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StockTrade.API.Models;
using StockTrade.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using StockTrade.API.Controllers.Api;
using Microsoft.AspNetCore.Http;
using StockTrade.API.Models.DTO;
using StockTrade.API.Filters;

namespace StockTrade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class PortfolioController : BaseApiController
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService, ILogger<PortfolioController> logger, IOptions<AppOptions> settings) : base(logger, settings)
        {
            _portfolioService = portfolioService;
        }
        /// <summary>
        /// Get a portfolio with a specific identity
        /// </summary>
        /// <returns>Portfolio payload is returned</returns>
        /// <response code="200">Portfolio found</response>
        /// <response code="404">No portfolio found</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PortfolioModelDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound),]
        [HttpGet("{portfolioId}")]
        public Task<IActionResult> Get(Guid portfolioId)
        {
            return ApiGetResponse(async () => await _portfolioService.GetAsync(portfolioId));
        }
        /// <summary>
        /// Delete an existing portfolio
        /// </summary>
        /// <returns>nothing</returns>
        /// <response code="200">Portfolio found and deleted</response>
        /// <response code="404">No portfolio found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("remove/{portfolioId}")]
        public Task<IActionResult> Remove(Guid portfolioId)
        {
            return ApiDeletedResponse(async () => await _portfolioService.RemoveAsync(portfolioId));
        }
        /// <summary>
        /// Add a portfolio
        /// </summary>
        /// <returns>Portfolio payload is returned</returns>
        /// <response code="200">Success portfolio add database</response>
        /// <response code="409">Portfolio already exists</response>
        /// <response code="422">Invalid model</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PortfolioModelDTO))]        
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("add")]
        public Task<IActionResult> Add([FromBody] PortfolioModel portfolioModel)
        {
            //if (HttpContext.User.Identity is ClaimsIdentity identity)
            //    portfolioModel.UserId = identity.FindFirst(ClaimTypes.Email).Value;

            //removed all the jwt authorization code, will hard code the email 
            portfolioModel.UserId = "antroach2000@gmail.com";

            return ApiCreatedResponse("api/v1/portfolio", async () => await _portfolioService.ExistsAsync(portfolioModel), async () => await _portfolioService.AddAsync(portfolioModel));
        }
    }
}
