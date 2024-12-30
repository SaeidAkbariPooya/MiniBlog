using Microsoft.EntityFrameworkCore;
using MiniBlog.Core.Contracts.Categories.Queries;
using MiniBlog.Core.Contracts.Categories.Queries.GetAllCategory;
using MiniBlog.Core.Contracts.Categories.Queries.GetCategoryById;
using MiniBlog.Infra.Data.Sql.Queries.Common;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Infra.Data.Sql.Queries;

namespace MiniPerson.Infra.Data.Sql.Queries.Categories
{
    public class CategoryQueryRepository : BaseQueryRepository<MiniBlogQueryDbContext>, ICategoryQueryRepository
    {
        public CategoryQueryRepository(MiniBlogQueryDbContext dbContext) : base(dbContext)
        {

        }

        public PagedData<CategoryDto> Execute(GetAllCategoryQuery catList)
        {
            PagedData<CategoryDto> result = new();


            var query = _dbContext.Categories.AsNoTracking();

            result.QueryResult = query.OrderByDescending(c => c.Id).Skip(catList.SkipCount)
                        .Take(catList.PageSize)
                        .Select(c => new CategoryDto
                        {
                            Id = c.Id,
                            Title = c.Title
                        }).ToList();


            if (catList.NeedTotalCount)
            {
                result.TotalCount = query.Count();
            }

            return result;

        }

        public async Task<CategoryDto> Execute(long Id)
                => await _dbContext.Categories.Where(c => c.Id.Equals(Id)).Select(c => new CategoryDto()
                {
                    Id = c.Id,
                    BusinessId = c.BusinessId,
                    Title = c.Title,
                }).FirstOrDefaultAsync();
    }
}
