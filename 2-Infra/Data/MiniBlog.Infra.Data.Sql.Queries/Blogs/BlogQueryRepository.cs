using Microsoft.EntityFrameworkCore;
using MiniBlog.Core.Contracts.Blogs.Queries;
using MiniBlog.Core.Contracts.Blogs.Queries.GetAllBlog;
using MiniBlog.Core.Contracts.Blogs.Queries.GetBlogById;
using MiniBlog.Infra.Data.Sql.Queries.Common;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Infra.Data.Sql.Queries;

namespace MiniBlog.Infra.Data.Sql.Queries.Blogs
{
    public class BlogQueryRepository : BaseQueryRepository<MiniBlogQueryDbContext>, IBlogQueryRepository
    {
        public BlogQueryRepository(MiniBlogQueryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<PagedData<BlogDto>> GetAll(GetAllBlogQuery query)
        {
            PagedData<BlogDto> data = new PagedData<BlogDto>();

            var blogs = await _dbContext.Blogs
                        .Include(b => b.BlogCategories)
                            .ThenInclude(b => b.Category)
                        .Include(b => b.BlogPhotos)
                            .ThenInclude(b => b.Photo)
                        .ToListAsync();

            data.QueryResult = blogs
            .OrderByDescending(b => b.Id)
            .Skip(query.SkipCount)
            .Take(query.PageSize)
            .Select(b => new BlogDto
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                BlogCategoeries = b.BlogCategories.Select(c => new BlogCategoeryDto
                {
                    CategoryId = c.CategoryId,
                    BlogId = c.BlogId,
                    Title = c.Category.Title
                }).ToList(),
                BlogPhotos = b.BlogPhotos.Select(p => new BlogPhotoDto
                {
                    PhotoId = p.PhotoId,
                    BlogId = p.BlogId,
                    Title = p.Photo.Title,
                    ImageUrl = p.Photo.ImageUrl                
                }).ToList()
            })
            .ToList();

            if (query.NeedTotalCount)
            {
                data.TotalCount = blogs.Count;
            }

            return data;
        }

        public async Task<BlogDto> GetBlogById(GetBlogByIdQuery query)
        {
            var blog = await _dbContext.Blogs
            .Include(b => b.BlogCategories)
                .ThenInclude(b => b.Category)
            .Include(b => b.BlogPhotos)
                .ThenInclude(b => b.Photo)
            .Select(b => new BlogDto
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                BlogCategoeries = b.BlogCategories.Select(c => new BlogCategoeryDto
                {
                    CategoryId = c.CategoryId,
                    BlogId = c.BlogId,
                    Title = c.Category.Title
                }).ToList(),
                BlogPhotos = b.BlogPhotos.Select(c => new BlogPhotoDto
                {
                    PhotoId = c.PhotoId,
                    BlogId = c.BlogId,
                    ImageUrl = c.Photo.ImageUrl,
                    Title = c.Photo.Title
                }).ToList()
            })
            .FirstOrDefaultAsync(b => b.Id.Equals(query.Id));

            return blog;
        }
    }
}