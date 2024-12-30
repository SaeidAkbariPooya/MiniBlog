using MiniBlog.Core.Contracts.Blogs.Queries.GetAllBlog;
using MiniBlog.Core.Contracts.Blogs.Queries.GetBlogById;
using MiniBlog.Core.Contracts.Blogs.Queries;
using MiniBlog.Core.Contracts.Categories.Queries;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Utilities;
using MiniBlog.Core.Contracts.Photos.Queries;

namespace MiniBlog.Core.ApplicationService.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdHandler : QueryHandler<GetBlogByIdQuery, BlogDto>
    {
        private readonly IBlogQueryRepository _blogQueryRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly IPhotoQueryRepository _photoQueryRepository;
        public GetBlogByIdHandler(ZaminServices zaminServices, 
            IBlogQueryRepository blogQueryRepository,
            ICategoryQueryRepository categoryQueryRepository,
            IPhotoQueryRepository photoQueryReposito)
            : base(zaminServices)
        {
            _blogQueryRepository = blogQueryRepository;
            _categoryQueryRepository = categoryQueryRepository;
            _photoQueryRepository = photoQueryReposito;
        }
        public override async Task<QueryResult<BlogDto>> Handle(GetBlogByIdQuery query)
        {
            var blog = await _blogQueryRepository.GetBlogById(query);
            if (blog.BlogCategoeries != null && blog.BlogCategoeries.Count > 0)
            {
                await GetBlogCategory(blog);
            }
            if (blog.BlogPhotos != null && blog.BlogPhotos.Count > 0)
            {
                await GetBlogPhotos(blog);
            }
            return Result(blog);
        }
        private async Task GetBlogCategory(BlogDto blog)
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
