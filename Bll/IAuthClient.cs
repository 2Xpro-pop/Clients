using Dal;

namespace Bll;
public interface IAuthClient
{
    Task<JwtResponse> LoginAsync(string login, string password);
    Task CreateUserAsync(string login, string password, string role, int branchOfficeId);
    Task<JwtResponse> GetAccessToken(string refreshToken);
}
