using FundAdmin.API.Models.Enums;

namespace FundAdmin.API.DTOs.Transaction
{
    public class CreateTransactionDto
    {
        public Guid InvestorId { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
    }
}
