using FundAdmin.API.Models.Enums;

namespace FundAdmin.API.DTOs.Transaction
{
    public class TransactionResponseDto
    {
        public Guid TransactionId { get; set; }
        public Guid InvestorId { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
