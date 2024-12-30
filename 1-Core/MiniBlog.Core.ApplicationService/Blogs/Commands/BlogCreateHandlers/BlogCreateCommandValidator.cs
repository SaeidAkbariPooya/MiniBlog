using FluentValidation;
using MiniBlog.Core.Contracts.Blogs.Commands.CreateBlog;
using Zamin.Core.Domain.Toolkits.ValueObjects;
using Zamin.Extensions.Translations.Abstractions;

namespace MiniBlog.Core.ApplicationService.Blogs.Commands.BlogCreateHandlers
{
    public class BlogCreateCommandValidator : AbstractValidator<BlogCreateCommand>
    {
        public BlogCreateCommandValidator(ITranslator translator)
        {
            RuleFor(c => c.Title)
                   .NotNull().WithMessage(translator["Required", nameof(Title)])
                   .MinimumLength(3).WithMessage(translator["MinimumLength", nameof(Title), "3"])
                   .MaximumLength(100).WithMessage(translator["MaximumLength", nameof(Title), "100"]);

            RuleFor(c => c.Description)
                   .NotNull().WithMessage(translator["Required", nameof(Description)])
                   .MinimumLength(3).WithMessage(translator["MinimumLength", nameof(Description), "3"])
                   .MaximumLength(300).WithMessage(translator["MaximumLength", nameof(Description), "300"]);

    //        RuleFor(c => c.BlogCategories.)
    //.NotNull().NotEmpty()
    //.WithMessage(translator["Required", "CategoryIds"])
    //.Must(BeExist).WithMessage(translator["Invalid category found!"]);
        }
    }
}
