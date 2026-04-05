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
        [ProducesResponseType(typeof(FundResponseDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<FundResponseDto>>> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a fund by its unique identifier.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FundResponseDto>> Get(Guid id)
        {
            var fund = await _service.GetByIdAsync(id);

            if (fund == null)
                return NotFound();

            return Ok(fund);
        }

        /// <summary>
        /// Creates a new fund.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FundResponseDto>> Post(CreateFundDto dto)
        {
            var result = await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(Get),
                new { id = result.FundId },
                result);
        }

        /// <summary>
        /// Updates an existing fund.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Put(Guid id, UpdateFundDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        /// <summary>
        /// Updates an existing fund.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
