namespace FundAdmin.API.DTOs.Fund
{
    public class FundResponseDto
    {
        public Guid FundId { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
