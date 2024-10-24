using justmami.Domain.Requests;
using justmami.Domain.Responses;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace justmami.Server.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _config;
    private UserRepository _userRepository;
    public AuthService(IConfiguration config)
    {
        _userRepository = new UserRepository();
        _config = config;
    }

    public string CreateRefreshToken()
    {
        var randomNumber = new byte[32];

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);

        }

        return Convert.ToBase64String(randomNumber);
    }
    public string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Firstname + " " + user.Lastname),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("ID", user.Id.ToString()),
                new Claim("Confirmed", user.IsEmailConfirmed.ToString())
            };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
    public async Task<TokenResponse> LoginAsync(LoginRequest request)
    {
        TokenResponse response = new TokenResponse();
        User user = await _userRepository.VerifyUser(request);

        if (user == null)
        {
            response.Success = false;
            response.ErrorMessage = "Invalid email or password";
            return response;
        }

        string token = CreateToken(user);
        string refreshToken = CreateRefreshToken();

        //assign refreshToken
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(30);

        await _userRepository.UpdateAsync(user);

        return new TokenResponse
        {
            Token = token,
            RefreshToken = refreshToken,
            Success = true
        };
    }
    public async Task<TokenResponse> RegisterAsync(RegisterRequest request)
    {
        TokenResponse response = new TokenResponse();

        var user = new User
        {
            Email = request.Email,
            Firstname = request.Firstname,
            Lastname = request.Lastname,
            Password = request.Password,
        };


        user = await _userRepository.AddAsync(user);

        if (user == null)
        {
            response.Success = false;
            response.ErrorMessage = "Username or Email are already taken";
            return response;
        }

        //Create Tokens for the user
        string token = CreateToken(user);
        string refreshToken = CreateRefreshToken();

        //assign refreshToken
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(30);

        await _userRepository.UpdateAsync(user);

        return new TokenResponse
        {
            Token = token,
            RefreshToken = refreshToken,
            Success = true
        };
    }
}

