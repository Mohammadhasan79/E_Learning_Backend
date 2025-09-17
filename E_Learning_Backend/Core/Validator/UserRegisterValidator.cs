using E_Learning_Backend.Core.DTOs.UserDTO;
using FluentValidation;

namespace E_Learning_Backend.Core.Validator
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterValidator() 
        {
            RuleFor(x => x.FullName).NotNull().NotEmpty().WithMessage("Name requarid");
            RuleFor(x => x.FullName).MinimumLength(5).WithMessage("Name most be 8 charactor incorrect");
            RuleFor(x => x.UserName).NotNull().NotEmpty().MinimumLength(5).WithMessage("User Name incorrect");
            RuleFor(x => x.Email).EmailAddress().WithMessage("check email address format");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(5).WithMessage("Check Password");
            RuleFor(x => x.Role).NotEmpty().Must(r => r == "Student" || r == "Instructor" || r == "Admin").WithMessage("Role not exist");
        }
    }
}
