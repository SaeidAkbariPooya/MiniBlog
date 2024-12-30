using FluentValidation;
using MiniBlog.Core.Contracts.Blogs.Commands.DeleteBlog;
using Zamin.Extensions.Translations.Abstractions;

namespace MiniBlog.Core.ApplicationService.Blogs.Commands.BlogDeleteHandlers
{
    internal class BlogDeleteCommandValidator : AbstractValidator<BlogDeleteCommand>
    {
        public BlogDeleteCommandValidator(ITranslator translator)
        {
            RuleFor(c => c.BlogId)
                   .NotNull().WithMessage(translator["Required", "BlogId"])
                   .NotEmpty().WithMessage(translator["Required", "BlogId"]);
        }
    }
}
