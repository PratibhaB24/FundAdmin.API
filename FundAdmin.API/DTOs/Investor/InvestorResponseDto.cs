namespace FundAdmin.API.DTOs.Investor
{
    public class InvestorResponseDto
    {
        public Guid InvestorId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Guid FundId { get; set; }
    }
}
