using JWT.Contracts;
using JWT.DataAcces;
using JWT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YamlDotNet.Core.Tokens;



namespace JWT.Controllers;

[ApiController]
[Route("[controller]/[action]")]

public class UserController(UserDbContext dbContext) : ControllerBase
{
    private readonly UserDbContext _dbContext = dbContext;

    [HttpPost]
    public async Task<IActionResult> SignUp([FromBody] UserRegistrationRequest request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return BadRequest(new { Errors = errors });
        }

        if (await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == request.Email).ConfigureAwait(false) != null)
        {
            return BadRequest(new { Errors = new List<string> { "Пользователь с таким email'ом уже существует!" } });
        }
        var hashedPassword = PasswordHasher.HashPassword(request.Password);
        var user = new User { Username = request.Username, Email = request.Email, Password = hashedPassword };

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

    [HttpPost]
    public async Task<IActionResult> SignIn([FromBody] UserLoginRequest request, CancellationToken ct)
    {

        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return BadRequest(new { Errors = errors });
        }

        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == request.Email).ConfigureAwait(false);

        if (user == null)
        {
            return BadRequest(new { Errors = new List<string> { "Данный email не зарегестрирован" } });
        }
        if (!PasswordHasher.VerifyHashedPassword(user.Password, request.Password))
        {
            return BadRequest(new { Errors = new List<string> { "Неверный паролль!" } });
        }

        return Ok("Login successful");
    }
}
