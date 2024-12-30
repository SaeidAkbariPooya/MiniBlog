using MiniBlog.Core.Contracts.Blogs.Queries.GetAllBlog;

namespace MiniBlog.Core.Contracts.Blogs.BlogCategory.Queries
{
    public interface IBlogCategoryQueyRepository
    {
        Task<BlogCategoeryDto> GetBlogCategoryById(long query);
    }
}
