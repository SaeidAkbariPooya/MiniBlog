using FluentValidation;
using MiniBlog.Core.Contracts.Categories.Commands.CategoryCreate;
using Zamin.Core.Domain.Toolkits.ValueObjects;
using Zamin.Extensions.Translations.Abstractions;

namespace MiniBlog.Core.ApplicationService.Categories.Commands.CategoryCreateHandlers
{
    public class CategoryCreateCommandValidator : AbstractValidator<CategoryCreateCommand>
    {
        public CategoryCreateCommandValidator(ITranslator translator)
        {
            RuleFor(c => c.Title)
                 .NotNull().WithMessage(translator["Required", nameof(Title)])
                 .MinimumLength(3).WithMessage(translator["MinimumLength", nameof(Title), "2"])
                 .MaximumLength(100).WithMessage(translator["MaximumLength", nameof(Title), "100"]); 
        }
    }
}
