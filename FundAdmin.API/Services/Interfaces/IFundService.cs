using FundAdmin.API.DTOs.Fund;
using FundAdmin.API.Models;

namespace FundAdmin.API.Services.Interfaces
{
    public interface IFundService
    {
        Task<IEnumerable<FundResponseDto>> GetAllAsync();
        Task<FundResponseDto> GetByIdAsync(Guid id);
        Task<FundResponseDto> CreateAsync(CreateFundDto dto);
        Task UpdateAsync(Guid id, UpdateFundDto dto);
        Task DeleteAsync(Guid id);
    }
}
