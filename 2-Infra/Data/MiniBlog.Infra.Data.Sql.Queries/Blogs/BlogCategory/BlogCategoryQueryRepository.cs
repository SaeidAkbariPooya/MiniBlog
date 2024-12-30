using Microsoft.EntityFrameworkCore;
using MiniBlog.Core.Contracts.Blogs.BlogCategory.Queries;
using MiniBlog.Core.Contracts.Blogs.Queries.GetAllBlog;
using MiniBlog.Infra.Data.Sql.Queries.Common;
using Zamin.Infra.Data.Sql.Queries;

namespace MiniBlog.Infra.Data.Sql.Queries.Blogs.BlogCategory
{
    public class BlogCategoryQueryRepository : BaseQueryRepository<MiniBlogQueryDbContext>, IBlogCategoryQueyRepository
    {
        public BlogCategoryQueryRepository(MiniBlogQueryDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<BlogCategoeryDto> GetBlogCategoryById(long query)
         => await _dbContext.BlogCategories.Where(c => c.Id.Equals(query)).Select(c => new BlogCategoeryDto()
         {
             CategoryId = c.CategoryId,
         }).FirstOrDefaultAsync();
    }
}
