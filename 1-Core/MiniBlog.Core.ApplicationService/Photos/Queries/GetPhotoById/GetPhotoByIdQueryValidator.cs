using FluentValidation;
using MiniBlog.Core.Contracts.Photos.Queries.GetPhotoById;
using Zamin.Extensions.Translations.Abstractions;

namespace MiniBlog.Core.ApplicationService.Photos.Queries.GetPhotoById
{
    public class GetPhotoByIdQueryValidator : AbstractValidator<GetPhotoByIdQuery>
    {
        public GetPhotoByIdQueryValidator(ITranslator translator)
        {
            //     RuleFor(query => query.Id)
            //             .NotNull().WithMessage(translator["Required", nameof(GetBlogByIdQuery.Id)]);

            RuleFor(c => c.PhotoId)
                   .NotNull().WithMessage(translator["Required", "PhotoId"])
                   .NotEmpty().WithMessage(translator["Required", "PhotoId"]);
        }
    }
}
