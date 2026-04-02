using FundAdmin.API.DTOs.Transaction;
using FundAdmin.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundAdmin.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionsController(ITransactionService service)
        {
            _service = service;
        }

        /// <summary>
        /// Creates a new transaction (Subscription or Redemption).
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(CreateTransactionDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok("Transaction created successfully");
        }

        /// <summary>
        /// Retrieves all transactions for a specific investor.
        /// </summary>
        [HttpGet("investor/{investorId}")]
        public async Task<IActionResult> GetByInvestor(Guid investorId)
        {
            var result = await _service.GetByInvestorAsync(investorId);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves total subscribed and redeemed amounts for a fund.
        /// </summary>
        [HttpGet("fund/{fundId}/summary")]
        public async Task<IActionResult> GetFundSummary(Guid fundId)
        {
            var result = await _service.GetFundSummaryAsync(fundId);
            return Ok(result);
        }
    }
}
