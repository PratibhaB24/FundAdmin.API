using FundAdmin.API.Models.Enums;

namespace FundAdmin.API.Models
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public Guid InvestorId { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public Investor Investor { get; set; }
    }
}
