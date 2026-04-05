using Asp.Versioning;
using FundAdmin.API.DTOs.Transaction.v2;
using FundAdmin.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundAdmin.API.Controllers.v2
{
    [Authorize]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/reports")]
    public class ReportsController : ControllerBase
    {
        private readonly ITransactionService _service;

        public ReportsController(ITransactionService service)
        {
            _service = service;
        }

        /// <summary>
        /// v2 - Net investment and investor count
        /// </summary>
        [HttpGet("fund/{fundId}/summary")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<FundAnalyticsDto>> GetFundAnalytics(Guid fundId)
        {
            var result = await _service.GetFundAnalyticsAsync(fundId);

            return Ok(result);
        }
    }
}
