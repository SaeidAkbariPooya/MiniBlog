using FluentValidation;
using MiniBlog.Core.Contracts.Photos.Commands.CategoryPhoto;
using Zamin.Extensions.Translations.Abstractions;

namespace MiniBlog.Core.ApplicationService.Photos.Commands.PhotoCreateHandlers
{
    public class PhotoCreateCommandValidator : AbstractValidator<PhotoCreateCommand>
    {
        public PhotoCreateCommandValidator(ITranslator translator)
        {
            RuleFor(c => c.ImageUrl)
                   .NotNull().WithMessage(translator["Required", "ImageUrl"])
                   .NotEmpty().WithMessage(translator["Required", "ImageUrl"])
                   .MinimumLength(1).WithMessage(translator["MinimumLength", "ImageUrl", "1"])
                   .MaximumLength(300).WithMessage(translator["MaximumLength", "ImageUrl", "300"]);

            RuleFor(c => c.Title)
                   .NotNull().WithMessage(translator["Required", "Title"])
                   .NotEmpty().WithMessage(translator["Required", "Title"])
                   .MinimumLength(3).WithMessage(translator["MinimumLength", "Title", "3"])
                   .MaximumLength(100).WithMessage(translator["MaximumLength", "Title", "100"]);
        }
    }
}
