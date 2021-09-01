using FluentValidation;

namespace AuthJWT.WebAPI.Models
{
    public class UserPasswordValidator : AbstractValidator<UserPassword>
    {
        public UserPasswordValidator()
        {
            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Informe a senha.");
        }        
    }
}
