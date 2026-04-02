using FundAdmin.API.Data;
using FundAdmin.API.DTOs.Transaction;
using FundAdmin.API.Exceptions;
using FundAdmin.API.Models;
using FundAdmin.API.Models.Enums;
using FundAdmin.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FundAdmin.API.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _context;

        public TransactionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CreateTransactionDto dto)
        {
            if (dto.Amount <= 0)
                throw new BadRequestException("Amount must be greater than zero");

            var investor = await _context.Investors.FindAsync(dto.InvestorId);

            if (investor == null)
                throw new NotFoundException("Investor not found");

            var transaction = new Transaction
            {
                TransactionId = Guid.NewGuid(),
                InvestorId = dto.InvestorId,
                Type = dto.Type,
                Amount = dto.Amount,
                TransactionDate = DateTime.UtcNow
            };

            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TransactionResponseDto>> GetByInvestorAsync(Guid investorId)
        {
            var transactions = await _context.Transactions
                .Where(t => t.InvestorId == investorId)
                .ToListAsync();

            return transactions.Select(t => new TransactionResponseDto
            {
                TransactionId = t.TransactionId,
                InvestorId = t.InvestorId,
                Type = t.Type,
                Amount = t.Amount,
                TransactionDate = t.TransactionDate
            });
        }

        public async Task<FundTransactionSummaryDto> GetFundSummaryAsync(Guid fundId)
        {
            var transactions = await _context.Transactions
                .Include(t => t.Investor)
                .Where(t => t.Investor.FundId == fundId)
                .ToListAsync();

            return new FundTransactionSummaryDto
            {
                FundId = fundId,
                TotalSubscribed = transactions
                    .Where(t => t.Type == TransactionType.Subscription)
                    .Sum(t => t.Amount),

                TotalRedeemed = transactions
                    .Where(t => t.Type == TransactionType.Redemption)
                    .Sum(t => t.Amount)
            };
        }
    }
}
