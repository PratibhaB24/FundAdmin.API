using Asp.Versioning;
using FundAdmin.API.DTOs.Transaction;
using FundAdmin.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FundAdmin.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly ITransactionService _service;

        public ReportsController(ITransactionService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get fund transaction summary (v1) : Retrieves total subscribed and redeemed amounts for a fund
        /// </summary>
        [HttpGet("fund/{fundId}/summary")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<FundTransactionSummaryDto>> GetFundSummary(Guid fundId)
        {
            var result = await _service.GetFundSummaryAsync(fundId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
