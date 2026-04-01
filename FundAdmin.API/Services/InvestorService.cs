using FundAdmin.API.DTOs.Investor;
using FundAdmin.API.Models;
using FundAdmin.API.Repositories;
using FundAdmin.API.Services.Interfaces;

namespace FundAdmin.API.Services
{
    public class InvestorService : IInvestorService
    {
        private readonly IGenericRepository<Investor> _repo;

        public InvestorService(IGenericRepository<Investor> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<InvestorResponseDto>> GetAllAsync()
        {
            var investors = await _repo.GetAllAsync();

            return investors.Select(i => new InvestorResponseDto
            {
                InvestorId = i.InvestorId,
                FullName = i.FullName,
                Email = i.Email,
                FundId = i.FundId
            });
        }

        public async Task<InvestorResponseDto> GetByIdAsync(Guid id)
        {
            var investor = await _repo.GetByIdAsync(id);

            if (investor == null) return null;

            return new InvestorResponseDto
            {
                InvestorId = investor.InvestorId,
                FullName = investor.FullName,
                Email = investor.Email,
                FundId = investor.FundId
            };
        }

        public async Task CreateAsync(CreateInvestorDto dto)
        {
            var investor = new Investor
            {
                InvestorId = Guid.NewGuid(),
                FullName = dto.FullName,
                Email = dto.Email,
                FundId = dto.FundId
            };

            await _repo.AddAsync(investor);
            await _repo.SaveAsync();
        }

        public async Task UpdateAsync(Guid id, UpdateInvestorDto dto)
        {
            var investor = await _repo.GetByIdAsync(id);

            if (investor == null) return;

            investor.FullName = dto.FullName;
            investor.Email = dto.Email;

            _repo.Update(investor);
            await _repo.SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var investor = await _repo.GetByIdAsync(id);

            if (investor == null) return;

            _repo.Delete(investor);
            await _repo.SaveAsync();
        }
    }
}
