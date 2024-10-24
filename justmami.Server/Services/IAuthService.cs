using justmami.Domain.Requests;
using justmami.Domain.Responses;

namespace justmami.Server.Services;

public interface IAuthService
{
    Task<TokenResponse> RegisterAsync(RegisterRequest request);
    Task<TokenResponse> LoginAsync(LoginRequest request);

    string CreateToken(User user);
    string CreateRefreshToken();
}
