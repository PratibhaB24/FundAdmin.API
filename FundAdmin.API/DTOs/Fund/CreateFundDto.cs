namespace FundAdmin.API.DTOs.Fund
{
    public class CreateFundDto
    {
        public string Name { get; set; }
        public string Currency { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
