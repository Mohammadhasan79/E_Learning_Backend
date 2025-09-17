using E_Learning_Backend.Core.DTOs.CourseDto;
using FluentValidation;

namespace E_Learning_Backend.Core.Validator
{
    public class CourseCreateValidator : AbstractValidator<CreateCourseDto>
    {
        public CourseCreateValidator() 
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().MaximumLength(50).WithMessage("TiTle Not Currect");

        }
    }
}
