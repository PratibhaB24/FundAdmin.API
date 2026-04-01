using FundAdmin.API.DTOs.Investor;

namespace FundAdmin.API.Services.Interfaces
{
    public interface IInvestorService
    {
        Task<IEnumerable<InvestorResponseDto>> GetAllAsync();
        Task<InvestorResponseDto> GetByIdAsync(Guid id);
        Task CreateAsync(CreateInvestorDto dto);
        Task UpdateAsync(Guid id, UpdateInvestorDto dto);
        Task DeleteAsync(Guid id);
    }
}
