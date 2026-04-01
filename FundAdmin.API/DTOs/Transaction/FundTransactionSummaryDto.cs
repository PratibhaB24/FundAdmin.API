namespace FundAdmin.API.DTOs.Transaction
{
    public class FundTransactionSummaryDto
    {
        public Guid FundId { get; set; }
        public decimal TotalSubscribed { get; set; }
        public decimal TotalRedeemed { get; set; }
    }
}
