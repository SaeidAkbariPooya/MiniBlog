using MiniBlog.Core.Contracts.Categories.Queries;
using MiniBlog.Core.Contracts.Categories.Queries.GetAllCategory;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Utilities;


namespace MiniBlog.Core.ApplicationService.Categories.Queries.GetAllCategory
{
    public class GetCategoriesQueryHandler : QueryHandler<GetAllCategoryQuery, PagedData<CategoryDto>>
    {
        private readonly ICategoryQueryRepository _categoryCatQueryRepository;
        public GetCategoriesQueryHandler(ZaminServices zaminServices,
                                    ICategoryQueryRepository categoryCatQueryRepository) : base(zaminServices)
        {
            _categoryCatQueryRepository = categoryCatQueryRepository;
        }
        public override async Task<QueryResult<PagedData<CategoryDto>>> Handle(GetAllCategoryQuery query)
        {
            try
            {
                var result = _categoryCatQueryRepository.Execute(query);

                return Result(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
