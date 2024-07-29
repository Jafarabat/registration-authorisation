using JWT.Contracts;
using JWT.DataAcces;
using JWT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace JWT.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController(UserDbContext dbContext) : ControllerBase
{
    private readonly UserDbContext _dbContext = dbContext;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserRegistrationRequest request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            var g = ModelState.Values;
            var d = ModelState.ValidationState;
            return BadRequest(ModelState.Values.ToString());
        }

        if (await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == request.Email).ConfigureAwait(false) != null)
        {
            return BadRequest("Пользователь с таким email'ом уже существует!");
        }
        var hashedPassword = PasswordHasher.HashPassword(request.Password);
        var user = new User(request.Username, request.Email, hashedPassword);

        await _dbContext.Users.AddAsync(user, ct);
        await _dbContext.SaveChangesAsync(ct);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var user = await _dbContext.Users.ToListAsync();
        return Ok(user);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] GetByIdRequest request, CancellationToken ct)
    {
        var user = await _dbContext.Users.FindAsync(request.Id);
        if (user == null)
        {
            return NotFound("Пользователь не найден");
        }
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync(ct);

        return Ok("Пользователь успешно удален");

    }
}
