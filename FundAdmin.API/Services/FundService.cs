using FundAdmin.API.DTOs.Fund;
using FundAdmin.API.Models;
using FundAdmin.API.Repositories;
using FundAdmin.API.Services.Interfaces;

namespace FundAdmin.API.Services
{
    public class FundService : IFundService
    {
        private readonly IGenericRepository<Fund> _repo;

        public FundService(IGenericRepository<Fund> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<FundResponseDto>> GetAllAsync()
        {
            var funds = await _repo.GetAllAsync();

            return funds.Select(f => new FundResponseDto
            {
                FundId = f.FundId,
                Name = f.Name,
                Currency = f.Currency,
                LaunchDate = f.LaunchDate
            });
        }

        public async Task<FundResponseDto> GetByIdAsync(Guid id)
        {
            var fund = await _repo.GetByIdAsync(id);

            if (fund == null) return null;

            return new FundResponseDto
            {
                FundId = fund.FundId,
                Name = fund.Name,
                Currency = fund.Currency,
                LaunchDate = fund.LaunchDate
            };
        }

        public async Task<FundResponseDto> CreateAsync(CreateFundDto dto)
        {
            var fund = new Fund
            {
                FundId = Guid.NewGuid(),
                Name = dto.Name,
                Currency = dto.Currency,
                LaunchDate = dto.LaunchDate
            };

            await _repo.AddAsync(fund);
            await _repo.SaveAsync();

            return new FundResponseDto
            {
                FundId = fund.FundId,
                Name = fund.Name,
                Currency = fund.Currency,
                LaunchDate = fund.LaunchDate
            };
        }

        public async Task UpdateAsync(Guid id, UpdateFundDto dto)
        {
            var fund = await _repo.GetByIdAsync(id);

            if (fund == null) return;

            fund.Name = dto.Name;
            fund.Currency = dto.Currency;

            _repo.Update(fund);
            await _repo.SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var fund = await _repo.GetByIdAsync(id);

            if (fund == null) return;

            _repo.Delete(fund);
            await _repo.SaveAsync();
        }
    }
}
