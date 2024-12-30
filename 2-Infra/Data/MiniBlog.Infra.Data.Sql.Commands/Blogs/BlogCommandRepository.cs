using MiniBlog.Core.Contracts.Blogs.Commands;
using MiniBlog.Core.Domain.Blog.Entities;
using MiniBlog.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace MiniBlog.Infra.Data.Sql.Commands.Blogs
{
    public class BlogCommandRepository : BaseCommandRepository<Blog, MiniBlogCommandDbContext>,
        IBlogCommandRepository
    {
        public BlogCommandRepository(MiniBlogCommandDbContext dbContext) : base(dbContext)
        {
        }
        public async Task CreateBlogCategory(List<BlogCategory> blogCategories)
        {
            await _dbContext.BlogCategories.AddRangeAsync(blogCategories);
        }

        public async Task CreateBlogPhoto(List<BlogPhoto> blogPhotos)
        {
            await _dbContext.BlogPhotos.AddRangeAsync(blogPhotos);
        }
    }
}
