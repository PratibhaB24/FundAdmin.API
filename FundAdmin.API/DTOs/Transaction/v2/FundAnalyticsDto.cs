namespace FundAdmin.API.DTOs.Transaction.v2
{
    public class FundAnalyticsDto
    {
        public Guid FundId { get; set; }
        public decimal NetInvestment { get; set; }
        public int InvestorCount { get; set; }
    }
}
