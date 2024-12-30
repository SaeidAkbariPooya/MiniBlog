using MiniBlog.Core.Contracts.Blogs.Queries.GetAllBlog;

namespace MiniBlog.Core.Contracts.Blogs.BlogPhoto.Queries
{
    public interface IBlogPhotoQueyRepository
    {
        Task<BlogPhotoDto> GetBlogPhotoById(long query);
    }
}
