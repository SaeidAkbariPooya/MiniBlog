
using MiniBlog.Core.Contracts.Blogs.Queries.GetAllBlog;
using MiniBlog.Core.Contracts.Blogs.Queries.GetBlogById;
using Zamin.Core.Contracts.Data.Queries;

namespace MiniBlog.Core.Contracts.Blogs.Queries
{
    public interface IBlogQueryRepository
    {
        Task<PagedData<BlogDto>> GetAll(GetAllBlogQuery query);
        Task<BlogDto> GetBlogById(GetBlogByIdQuery query);
    }
}

