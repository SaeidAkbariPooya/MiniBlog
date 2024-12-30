using FluentValidation;
using MiniBlog.Core.Contracts.Categories.Commands.CategoryCreate;
using Zamin.Extensions.Translations.Abstractions;

namespace MiniBlog.Core.ApplicationService.Categories.Commands.CategoryUpdateHandlers
{
    public class CategoryUpdateCommandValidator : AbstractValidator<CategoryCreateCommand>
    {
        public CategoryUpdateCommandValidator(ITranslator translator)
        {
            RuleFor(c => c.Title)
                   .NotNull().WithMessage(translator["Required", "Title"])
                   .NotEmpty().WithMessage(translator["Required", "Title"])
                   .MinimumLength(3).WithMessage(translator["MinimumLength", "Title", "3"])
                   .MaximumLength(100).WithMessage(translator["MaximumLength", "Title", "100"]);
        }
    }
}
