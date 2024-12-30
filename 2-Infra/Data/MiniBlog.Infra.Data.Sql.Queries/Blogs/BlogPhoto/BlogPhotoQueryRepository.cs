using Microsoft.EntityFrameworkCore;
using MiniBlog.Core.Contracts.Blogs.BlogPhoto.Queries;
using MiniBlog.Core.Contracts.Blogs.Queries.GetAllBlog;
using MiniBlog.Infra.Data.Sql.Queries.Common;
using Zamin.Infra.Data.Sql.Queries;

namespace MiniBlog.Infra.Data.Sql.Queries.Blogs.BlogPhoto
{
    internal class BlogPhotoQueryRepository : BaseQueryRepository<MiniBlogQueryDbContext>, IBlogPhotoQueyRepository
    {
        public BlogPhotoQueryRepository(MiniBlogQueryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<BlogPhotoDto> GetBlogPhotoById(long query)
         => await _dbContext.BlogPhotos.Where(c => c.PhotoId.Equals(query)).Select(c => new BlogPhotoDto()
         {
              PhotoId = c.PhotoId,
         }).FirstOrDefaultAsync();
    }
}
