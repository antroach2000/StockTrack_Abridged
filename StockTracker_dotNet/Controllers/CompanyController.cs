using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StockTrade.API.Services.Interfaces;
using StockTrade.API.Models;
using System.Threading.Tasks;
using StockTrade.API.Controllers.Api;
using Microsoft.AspNetCore.Http;
using StockTrade.API.Models.DTO;
using System.Collections.Generic;

namespace StockTrade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class ASXListedCompaniesController : BaseApiController
    {
        private readonly ICompanyService _companyService;
        public ASXListedCompaniesController(ICompanyService companyService, ILogger<ASXListedCompaniesController> logger, IOptions<AppOptions> settings) : base(logger, settings)
        {
            _companyService = companyService;
        }
        /// <summary>
        /// Get company annual reports
        /// </summary>
        /// <returns>Annual report payload is returned</returns>
        /// <response code="200">Annual reports found</response>
        /// <response code="404">No annual reports found</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LatestAnnualReportDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("company/{stockCode}/reports/annual")]
        public Task<IActionResult> GetCompanyAnnualReports(string stockCode)
        {
            return ApiGetResponse(async () => await _companyService.GetCompanyAnnualReports(stockCode));
        }
        /// <summary>
        /// Get company dividend reports
        /// </summary>
        /// <returns>Dividend report payload is returned</returns>
        /// <response code="200">Dividend reports found</response>
        /// <response code="404">No dividend reports found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("company/{stockCode}/dividends/")]
        public Task<IActionResult> GetCompanyDividends(string stockCode)
        {
            return ApiGetResponse(async () => await _companyService.GetCompanyDividends(stockCode, null));
        }
        /// <summary>
        /// Get company dividend history
        /// </summary>
        /// <returns>Dividend history payload is returned</returns>
        /// <response code="200">Dividend history found</response>
        /// <response code="404">No dividend history found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("company/{stockCode}/dividends/history/years/{yearsHistory?}")]
        public Task<IActionResult> GetCompanyDividends(string stockCode, int? yearsHistory)
        {
            return ApiGetResponse(async () => await _companyService.GetCompanyDividends(stockCode, yearsHistory));
        }
        /// <summary>
        /// Get company people
        /// </summary>
        /// <returns>Company people payload is returned</returns>
        /// <response code="200">Company people found</response>
        /// <response code="404">No company people found</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DirectorDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("company/{stockCode}/people")]
        public Task<IActionResult> GetCompanyPeople(string stockCode)
        {
            return ApiGetResponse(async () => await _companyService.GetCompanyPeople(stockCode));
        }
        /// <summary>
        /// Get company announcements
        /// </summary>
        /// <returns>Company announcements payload is returned</returns>
        /// <response code="200">Company announcements found</response>
        /// <response code="404">No company announcements found</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AnnouncementDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("company/{stockCode}/announcements")]
        public Task<IActionResult> GetCompanyAnnouncements(string stockCode)
        {
            return ApiGetResponse(async () => await _companyService.GetCompanyAnnouncements(stockCode));
        }
        /// <summary>
        /// Get company sharedata
        /// </summary>
        /// <returns>Company sharedata payload is returned</returns>
        /// <response code="200">Company sharedata found</response>
        /// <response code="404">No company sharedata found</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarketPriceListDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("company/{stockCode}/sharedata/days/{days}")]
        public Task<IActionResult> GetCompanyShareData(string stockCode, int days)
        {
            return ApiGetResponse(async () => await _companyService.GetCompanyShareData(stockCode, days));
        }
    }
}