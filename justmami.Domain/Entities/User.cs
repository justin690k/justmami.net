﻿using System.Security.Cryptography;
using System.Text;

namespace justmami.Domain.Entities;
public class User : Entity
{
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public bool IsEmailConfirmed { get; set; } = false;
    public int? Phone_number { get; set; }
    public bool IsPhoneConfirmed { get; set; } = false;
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExpiryTime { get; set; }

    //TODO Add CalanderId for a connection
}

public static class Userextensions
{
    public static string GeneratePassword()
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;

        for(int i = 0; i < 16; i++)
        {
            //Convert a random Double value to a char
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 25)));
            builder.Append(ch); 
        }

        return builder.ToString();
    }

    public static string HashPassword(this User user) => GetHashString(user.Password);

    private static byte[] GetHash(string inputString)
    {
        using HashAlgorithm algorithm = SHA256.Create();
        return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
    }

    private static string GetHashString(string inputString)
    {
        StringBuilder sb = new();
        foreach (byte b in GetHash(inputString))
            _ = sb.Append(b.ToString("X2"));

        return sb.ToString();
    }
}
