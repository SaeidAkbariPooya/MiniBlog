using MiniBlog.Core.Contracts.Categories.Queries.GetAllCategory;
using MiniBlog.Core.Contracts.Categories.Queries.GetCategoryById;
using Zamin.Core.Contracts.Data.Queries;

namespace MiniBlog.Core.Contracts.Categories.Queries
{
    public interface ICategoryQueryRepository
    {
        Task<CategoryDto> Execute(long Id);
        public PagedData<CategoryDto> Execute(GetAllCategoryQuery query);
    }
}
