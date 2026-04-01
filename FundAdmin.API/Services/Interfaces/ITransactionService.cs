using FundAdmin.API.DTOs.Transaction;

namespace FundAdmin.API.Services.Interfaces
{
    public interface ITransactionService
    {
        Task CreateAsync(CreateTransactionDto dto);
        Task<IEnumerable<TransactionResponseDto>> GetByInvestorAsync(Guid investorId);
        Task<FundTransactionSummaryDto> GetFundSummaryAsync(Guid fundId);
    }
}
