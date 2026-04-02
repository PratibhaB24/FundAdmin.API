using FundAdmin.API.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FundAdmin.API.DTOs.Transaction
{
    public class CreateTransactionDto
    {
        [Required]
        public Guid InvestorId { get; set; }
        [Required]
        public TransactionType Type { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be positive")]
        public decimal Amount { get; set; }
    }
}
