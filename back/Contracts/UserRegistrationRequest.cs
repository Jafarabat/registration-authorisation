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
    [MinLength(4, ErrorMessage = "Минимальная длина имени пользователя - 4 символов!")]
    [MaxLength(16, ErrorMessage = "Максимальная длина имени пользователя - 16 символов")]
    [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage ="В имени пользователя используйте только латинские буквы и арабские цифры")]
    public string Username { get; init; }


    [EmailAddress(ErrorMessage = "Некорректный формат email!")]
    [Required(ErrorMessage = "Поле email обязательно для заполнения!")]
    [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Недопустимые символы в email'e")]
    public string Email { get; init; }


    [Required(ErrorMessage = "Поле Password обязательно для заполнения!")]
    [MinLength(8, ErrorMessage = "Минимальная длина пароля - 8 символов!")]
    [RegularExpression(@"^(?=.*[A-Z])[a-zA-Z0-9!@#$%^&*()_+\-=\[\]{};':\\|,.<>\/?]*$", ErrorMessage = "В пароле используйте только латинские буквы, арабские цифры и специальные символы, и он должен содержать хотя бы одну заглавную букву.")]
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