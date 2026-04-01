using FundAdmin.API.DTOs.Fund;
using FundAdmin.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FundAdmin.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FundsController : ControllerBase
    {
        private readonly IFundService _service;

        public FundsController(IFundService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await _service.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post(CreateFundDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateFundDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
