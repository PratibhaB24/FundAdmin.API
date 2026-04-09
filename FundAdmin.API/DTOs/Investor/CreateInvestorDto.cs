using System.ComponentModel.DataAnnotations;

namespace FundAdmin.API.DTOs.Investor
{
    public class CreateInvestorDto
    {
        public string FullName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public Guid FundId { get; set; }

    }
}
