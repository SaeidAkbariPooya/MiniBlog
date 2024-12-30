using MiniBlog.Core.Contracts.Blogs.Queries;
using MiniBlog.Core.Contracts.Blogs.Queries.GetAllBlog;
using MiniBlog.Core.Contracts.Categories.Queries;
using MiniBlog.Core.Contracts.Photos.Queries;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Utilities;

namespace MiniBlog.Core.ApplicationService.Blogs.Queries.GetAllBlog
{
    public class GetAllBlogHandler : QueryHandler<GetAllBlogQuery, PagedData<BlogDto>>
    {
        private readonly IBlogQueryRepository _blogQueryRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly IPhotoQueryRepository _photoQueryRepository;

        public GetAllBlogHandler(ZaminServices zaminServices, 
            IBlogQueryRepository blogQueryRepository,
            ICategoryQueryRepository categoryQueryRepository,
            IPhotoQueryRepository photoQueryRepositor)
            : base(zaminServices)
        {
            _blogQueryRepository = blogQueryRepository;
            _categoryQueryRepository = categoryQueryRepository;
            _photoQueryRepository = photoQueryRepositor;
        }

        public override async Task<QueryResult<PagedData<BlogDto>>> Handle(GetAllBlogQuery query)
        {
            var blogs = await _blogQueryRepository.GetAll(query);

            foreach (var blog in blogs.QueryResult)
            {
                if (blog.BlogCategoeries != null && blog.BlogCategoeries.Count > 0)
                {
                    await GetBlogCategories(blog);
                }

                if (blog.BlogPhotos != null && blog.BlogPhotos.Count > 0)
                {
                    await GetBlogPhotos(blog);
                }
            }

            return await ResultAsync(blogs);
        }

        private async Task GetBlogCategories(BlogDto blog)
        {
            IList<BlogCategoeryDto> blogCategoeries = blog.BlogCategoeries;
            blog.BlogCategoeries = new List<BlogCategoeryDto>();
            foreach (var category in blogCategoeries)
            {
                var currentCategory = await _categoryQueryRepository.Execute(category.CategoryId);
                BlogCategoeryDto blogCategoeryQr = new BlogCategoeryDto
                {
                    CategoryId = currentCategory.Id,
                    BlogId = blog.Id,
                    Title = currentCategory.Title
                };
                blog.BlogCategoeries.Add(blogCategoeryQr);
            }
        }

        private async Task GetBlogPhotos(BlogDto blog)
        {
            IList<BlogPhotoDto> blogPhoto = blog.BlogPhotos;
            blog.BlogPhotos = new List<BlogPhotoDto>();
            foreach (var blogCurrent in blogPhoto)
            {
                var currentBlog = await _photoQueryRepository.GetById(blogCurrent.PhotoId);
                BlogPhotoDto blogPhotoQr = new BlogPhotoDto
                {
                    PhotoId = currentBlog.Id,
                    BlogId = blog.Id,
                    Title = currentBlog.Title,
                    ImageUrl = currentBlog.ImageUrl
                };
                blog.BlogPhotos.Add(blogPhotoQr);
            }
        }
    }
}
