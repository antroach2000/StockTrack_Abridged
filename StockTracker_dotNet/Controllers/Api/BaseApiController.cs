using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StockTrade.API.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sentry;

namespace StockTrade.API.Controllers.Api
{
    public abstract class BaseApiController : ControllerBase
    {
        public readonly ILogger _logger;
        private AppOptions _appOptions { get; set; }

        public BaseApiController(ILogger logger, IOptions<AppOptions> appOptions)
        {
            _logger = logger;
            _appOptions = appOptions.Value;
        }
        protected async Task<IActionResult> ApiGetResponse(Func<Task<object>> serviceQuery)
        {
            try
            {
                var serviceResult = await serviceQuery();

                return serviceResult == null ? StatusCode(StatusCodes.Status404NotFound, new { data = "Entity not found" }) : StatusCode(StatusCodes.Status200OK, new { data = serviceResult });
            }
            catch (Exception ex)
            {
                //SentrySdk.CaptureMessage($"ApiGetResponse->Exception {ex.Message} InnerException {ex.InnerException}");

                return StatusCode(StatusCodes.Status500InternalServerError, new { data = ex.Message });
            }
        }
        protected async Task<IActionResult> ApiDeletedResponse(Func<Task<object>> serviceQuery)
        {
            try
            {
                var serviceResult = await serviceQuery();

                if (serviceResult == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { data = "Entity not found" });
                }

                return StatusCode(StatusCodes.Status200OK, new { data = "Successful deletion" });
            }
            catch (Exception ex)
            {
                //SentrySdk.CaptureMessage($"ApiDeletedResponse->Exception {ex.Message} InnerException {ex.InnerException}");

                return StatusCode(StatusCodes.Status500InternalServerError, new { data = ex.Message });
            }
        }
        protected async Task<IActionResult> ApiCreatedResponse(string location, Func<Task<APIResponse>> serviceQuery1, Func<Task<object>> serviceQuery2)
        {
            try
            {
                APIResponse response = await serviceQuery1();

                if (response != null)
                {
                    return StatusCode(StatusCodes.Status409Conflict, response);
                }

                var serviceResult = await serviceQuery2();

                return StatusCode(StatusCodes.Status200OK, new { data = serviceResult });
            }
            catch (Exception ex)
            {
                //SentrySdk.CaptureMessage($"ApiCreatedResponse->location {location} Exception {ex.Message} InnerException {ex.InnerException}");

                return StatusCode(StatusCodes.Status500InternalServerError, new { data = ex.Message });
            }
        }
    }
}