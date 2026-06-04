using E_Learning_Backend.Core.DTOs.ContentDto;
using FluentValidation;

namespace E_Learning_Backend.Core.Validator
{
    public class ContentCreateValidator : AbstractValidator<CreateContentDto>
    {
        public ContentCreateValidator() 
        {
            RuleFor(x => x.Type).NotEmpty().Must(x => x == "Video" || x == "PDF" || x == "Text").WithMessage("insert correct type");
            RuleFor(x => x.Url)
            .NotEmpty()
            .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
            .WithMessage("Please enter a valid URL");
        }
    }
}
