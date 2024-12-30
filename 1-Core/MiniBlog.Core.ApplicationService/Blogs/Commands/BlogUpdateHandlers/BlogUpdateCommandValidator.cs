using FluentValidation;
using MiniBlog.Core.Contracts.Blogs.Commands.UpdateBlog;
using Zamin.Core.Domain.Toolkits.ValueObjects;
using Zamin.Extensions.Translations.Abstractions;

namespace MiniBlog.Core.ApplicationService.Blogs.Commands.BlogUpdateHandlers
{
    public class BlogUpdateCommandValidator : AbstractValidator<BlogUpdateCommand>
    {
        public BlogUpdateCommandValidator(ITranslator translator)
        {
            RuleFor(c => c.Title)
                    .NotNull().WithMessage(translator["Required", nameof(Title)])
                    .MinimumLength(3).WithMessage(translator["MinimumLength", nameof(Title), "2"])
                    .MaximumLength(100).WithMessage(translator["MaximumLength", nameof(Title), "100"]);

            RuleFor(c => c.Description)
                   .NotNull().WithMessage(translator["Required", nameof(Description)])
                   .MinimumLength(3).WithMessage(translator["MinimumLength", nameof(Description), "2"])
                   .MaximumLength(300).WithMessage(translator["MaximumLength", nameof(Description), "300"]);
        }
    }
}
