using JWT.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace JWT.DataAcces;

public class UserDbContext(IConfiguration configuration) : DbContext
{
    private readonly IConfiguration _configuration = configuration;

    public static string GetConnectionString(){
        return new NpgsqlConnectionStringBuilder(){
            Host = "localhost",
            Port = 5433,
            Database = "my_users",
            Username = "postgres",
            Password = "1"
        }.ConnectionString;
    }

    public DbSet<User> Users => Set<User>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(GetConnectionString());
    }
}