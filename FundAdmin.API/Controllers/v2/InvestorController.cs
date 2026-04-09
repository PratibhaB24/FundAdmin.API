using Asp.Versioning;
using FundAdmin.API.DTOs.Investor;
using FundAdmin.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FundAdmin.API.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class InvestorsController : ControllerBase
    {
        private readonly IInvestorService _service;

        public InvestorsController(IInvestorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvestorResponseDto>>> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvestorResponseDto>> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateInvestorDto dto)
        {
            await _service.CreateAsync(dto);
            return Created("", null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, UpdateInvestorDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}