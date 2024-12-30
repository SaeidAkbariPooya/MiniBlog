using FluentValidation;
using MiniBlog.Core.Contracts.Categories.Queries;
using MiniBlog.Core.Contracts.Categories.Queries.GetCategoryById;
using Zamin.Extensions.Translations.Abstractions;

namespace MiniBlog.Core.ApplicationService.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByBusinessIdQuery>
    {
        public GetCategoryByIdQueryValidator(ITranslator translator)
        {
            RuleFor(c => c.CategoryId)
                          .NotNull().WithMessage(translator["Required", "CategoryId"])
                          .NotEmpty().WithMessage(translator["Required", "CategoryId"]);
        }

        //private bool BeExist(long[] arg)
        //{
        //    var blog = _categoryCatQueryRepository.Execute(arg.ToList())
        //        .GetAwaiter().GetResult();

        //    return arg.All(x => blog.Select(c => c.Id).Contains(x));
        //}
    }
}
