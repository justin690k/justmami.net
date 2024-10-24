using justmami.Domain.Requests;
using justmami.Domain.Responses;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace justmami.Client.Services.User;

public class AuthService
{
    private readonly HttpClient _client;

    public AuthService(HttpClient client)
    {
        _client = client;
    }

    public async Task<TokenResponse> RegisterAsync(RegisterRequest request)
    {
        var response = await _client.PostAsJsonAsync("api/auth/register", request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TokenResponse>();
    }

    public async Task<TokenResponse> LoginAsync(LoginRequest request)
    {
        var response = await _client.PostAsJsonAsync("api/auth/login", request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TokenResponse>();
    }
}
