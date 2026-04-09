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
        [Required]
        public decimal Amount { get; set; }
    }
}
