using System.ComponentModel.DataAnnotations;

namespace JWT.Models;

public class User(string username, string email, string password)
{
    public Guid Id { get; init; }

    public string Username { get; set; } = username;

    public string Email { get; set; } = email;

    public string Password { get; set; } = password;

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}