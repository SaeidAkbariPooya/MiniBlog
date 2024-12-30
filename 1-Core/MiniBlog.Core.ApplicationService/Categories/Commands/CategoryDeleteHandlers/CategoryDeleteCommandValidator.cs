using FluentValidation;
using MiniBlog.Core.Contracts.Categories.Commands.CategoryDelete;
using Zamin.Extensions.Translations.Abstractions;

namespace MiniBlog.Core.ApplicationService.Categories.Commands.CategoryDeleteHandlers
{
    public class CategoryDeleteCommandValidator : AbstractValidator<CategoryDeleteCommand>
    {
        public CategoryDeleteCommandValidator(ITranslator translator)
        {
            RuleFor(c => c.CategoryId)
                   .NotNull().WithMessage(translator["Required", "CategoryId"])
                   .NotEmpty().WithMessage(translator["Required", "CategoryId"]);
        }
    }
}
