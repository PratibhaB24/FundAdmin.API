using FundAdmin.API.DTOs.Transaction;
using FundAdmin.API.DTOs.Transaction.v2;

namespace FundAdmin.API.Services.Interfaces
{
    public interface ITransactionService
    {
        Task CreateAsync(CreateTransactionDto dto);
        Task<IEnumerable<TransactionResponseDto>> GetByInvestorAsync(Guid investorId);
        Task<FundTransactionSummaryDto> GetFundSummaryAsync(Guid fundId);
        Task<FundAnalyticsDto> GetFundAnalyticsAsync(Guid fundId);
    }
}
