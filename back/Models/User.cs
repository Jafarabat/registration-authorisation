using System.ComponentModel.DataAnnotations;

namespace JWT.Models;

public class User
{
    public Guid Id { get; init; }

    public string Username { get; set; }=String.Empty;

    public string Email { get; set; }=String.Empty;

    public string Password { get; set; }=String.Empty;

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}