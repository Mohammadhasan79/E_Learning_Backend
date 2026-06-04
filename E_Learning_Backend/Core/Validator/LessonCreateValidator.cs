using E_Learning_Backend.Core.DTOs.LessonDto;
using FluentValidation;

namespace E_Learning_Backend.Core.Validator
{
    public class LessonCreateValidator : AbstractValidator<CreateLessonDto>
    {
        public LessonCreateValidator()
        {
        RuleFor(x => x.Title).NotEmpty().NotNull().MinimumLength(3).WithMessage("minimum Length is 3");
        RuleFor(x => x.Describtion).NotNull().NotEmpty().MaximumLength(500).WithMessage("maximum length is 500");

        }
    }
}
