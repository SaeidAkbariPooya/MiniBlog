using MiniBlog.Core.Contracts.Categories.Queries;
using MiniBlog.Core.Contracts.Categories.Queries.GetAllCategory;
using MiniBlog.Core.Contracts.Categories.Queries.GetCategoryById;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Utilities;

namespace MiniBlog.Core.ApplicationService.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : QueryHandler<GetCategoryByBusinessIdQuery, CategoryDto>
    {
        private readonly ICategoryQueryRepository _categoryCatQueryRepository;
        public GetCategoryByIdQueryHandler(ZaminServices zaminServices, ICategoryQueryRepository categoryCatQueryRepository) : base(zaminServices)
        {
            _categoryCatQueryRepository = categoryCatQueryRepository;
        }
        public override async Task<QueryResult<CategoryDto>> Handle(GetCategoryByBusinessIdQuery query)
        {
            return Result(await _categoryCatQueryRepository.Execute(query.CategoryId));
        }
    }
}
