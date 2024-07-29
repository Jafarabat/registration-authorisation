using System.ComponentModel.DataAnnotations;

namespace JWT.Contracts;

// public record UserRegistrationRequest(

// [Required(ErrorMessage = "Поле Username обязательно для заполнения")] 
// string Username,

// [EmailAddress(ErrorMessage = "Некорректный формат email.")]
// [Required]
// string Email,

// [Required(ErrorMessage = "Поле Password обязательно для заполнения")] 
// [MinLength(8, ErrorMessage = "Минимальная длина пароля - 8 символов.")]
// string Password, 

// [Required(ErrorMessage = "Поле Password Confirmation обязательно для заполнения")] 
// [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
// string PasswordConfirmation
// );
public record UserRegistrationRequest
{
    [Required(ErrorMessage = "Поле Username обязательно для заполнения!")]
    public string Username { get; init; }


    [EmailAddress(ErrorMessage = "Некорректный формат email!")]
    [Required(ErrorMessage = "Поле email обязательно для заполнения!")]
    public string Email { get; init; }


    [Required(ErrorMessage = "Поле Password обязательно для заполнения!")]
    [MinLength(8, ErrorMessage = "Минимальная длина пароля - 8 символов!")]
    public string Password { get; init; }


    [Required(ErrorMessage = "Поле Password Confirmation обязательно для заполнения!")]
    [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
    public string PasswordConfirmation { get; init; }


    public UserRegistrationRequest(string username, string email, string password, string passwordConfirmation)
    {
        Username = username;
        Email = email;
        Password = password;
        PasswordConfirmation = passwordConfirmation;
    }
}