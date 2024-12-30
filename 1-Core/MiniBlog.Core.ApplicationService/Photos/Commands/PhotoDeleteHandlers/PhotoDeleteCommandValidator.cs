using FluentValidation;
using MiniBlog.Core.Contracts.Photos.Commands.PhotoDelete;
using Zamin.Extensions.Translations.Abstractions;

namespace MiniBlog.Core.ApplicationService.Photos.Commands.PhotoDeleteHandlers
{
    public class PhotoDeleteCommandValidator : AbstractValidator<PhotoDeleteCommand>
    {
        public PhotoDeleteCommandValidator(ITranslator translator)
        {
            RuleFor(c => c.PhotoId)
                   .NotNull().WithMessage(translator["Required", "PhotoId"])
                   .NotEmpty().WithMessage(translator["Required", "PhotoId"]);
        }
    }
}
