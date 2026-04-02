using FundAdmin.API.DTOs.Fund;
using FundAdmin.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundAdmin.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FundsController : ControllerBase
    {
        private readonly IFundService _service;

        public FundsController(IFundService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all funds.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAllAsync());

        /// <summary>
        /// Retrieves a fund by its unique identifier.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await _service.GetByIdAsync(id));

        /// <summary>
        /// Creates a new fund.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post(CreateFundDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        /// <summary>
        /// Updates an existing fund.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateFundDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        /// <summary>
        /// Updates an existing fund.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
