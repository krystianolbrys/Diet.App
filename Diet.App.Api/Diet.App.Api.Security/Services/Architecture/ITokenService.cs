namespace Diet.App.Api.Security.Services.Architecture
{
    public interface ITokenService
    {
        string CreateToken(string data);

        bool CheckToken(string token);
    }
}
