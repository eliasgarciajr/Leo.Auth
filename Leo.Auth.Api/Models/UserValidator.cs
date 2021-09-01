using FluentValidation;

namespace AuthJWT.WebAPI.Models
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Username)
                .NotEmpty()
                .WithMessage("Informe o nome de usuário.");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Informe a senha.");
        }
    }
}
