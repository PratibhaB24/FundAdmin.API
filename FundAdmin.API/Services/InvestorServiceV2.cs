using AutoMapper;
using FundAdmin.API.DTOs.Investor;
using FundAdmin.API.Exceptions;
using FundAdmin.API.Models;
using FundAdmin.API.Repositories;
using FundAdmin.API.Services.Interfaces;

namespace FundAdmin.API.Services
{
    public class InvestorServiceV2 : IInvestorService
    {
        private readonly IGenericRepository<Investor> _repo;
        private readonly IMapper _mapper;

        public InvestorServiceV2(IGenericRepository<Investor> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InvestorResponseDto>> GetAllAsync()
        {
            var investors = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<InvestorResponseDto>>(investors);
        }

        public async Task<InvestorResponseDto> GetByIdAsync(Guid id)
        {
            var investor = await _repo.GetByIdAsync(id);

            if (investor == null)
                throw new NotFoundException($"Investor not found with Id: {id}");

            return _mapper.Map<InvestorResponseDto>(investor);
        }

        public async Task CreateAsync(CreateInvestorDto dto)
        {
            var investor = _mapper.Map<Investor>(dto);
            investor.InvestorId = Guid.NewGuid();

            await _repo.AddAsync(investor);
            await _repo.SaveAsync();
        }

        public async Task UpdateAsync(Guid id, UpdateInvestorDto dto)
        {
            var investor = await _repo.GetByIdAsync(id);

            if (investor == null)
                throw new NotFoundException($"Investor not found with Id: {id}");

            _mapper.Map(dto, investor);

            _repo.Update(investor);
            await _repo.SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var investor = await _repo.GetByIdAsync(id);

            if (investor == null)
                throw new NotFoundException($"Investor not found with Id: {id}");

            _repo.Delete(investor);
            await _repo.SaveAsync();
        }
    }
}
