using E_Learning_Backend.Core.DTOs.UserDTO;
using FluentValidation;

namespace E_Learning_Backend.Core.Validator
{
    public class UserLoginValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginValidator() 
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty().MinimumLength(8).WithMessage("User Name incorrect");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Check Password");
        }
    }
}
