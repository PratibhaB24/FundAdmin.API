using FundAdmin.API.DTOs.Investor;
using FundAdmin.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundAdmin.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class InvestorsController : ControllerBase
    {
        private readonly IInvestorService _service;

        public InvestorsController(IInvestorService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all investors.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAllAsync());

        /// <summary>
        /// Creates a new investor.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post(CreateInvestorDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        /// <summary>
        /// Updates an existing investor.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateInvestorDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        /// <summary>
        /// Updates an existing investor.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
