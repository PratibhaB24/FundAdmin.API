namespace FundAdmin.API.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(string username);
    }
}
