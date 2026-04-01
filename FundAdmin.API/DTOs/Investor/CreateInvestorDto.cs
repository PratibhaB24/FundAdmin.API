namespace FundAdmin.API.DTOs.Investor
{
    public class CreateInvestorDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public Guid FundId { get; set; }

    }
}
