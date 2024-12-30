using FluentValidation;
using MiniBlog.Core.Contracts.Blogs.Commands;
using MiniBlog.Core.Contracts.Blogs.Queries.GetBlogById;
using Zamin.Extensions.Translations.Abstractions;

namespace MiniBlog.Core.ApplicationService.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdValidator : AbstractValidator<GetBlogByIdQuery>
    {
        public GetBlogByIdValidator(ITranslator translator)
        {
            RuleFor(c => c.Id)
                          .NotNull().WithMessage(translator["Required", "Id"])
                          .NotEmpty().WithMessage(translator["Required", "Id"]);
        }
    }
}
