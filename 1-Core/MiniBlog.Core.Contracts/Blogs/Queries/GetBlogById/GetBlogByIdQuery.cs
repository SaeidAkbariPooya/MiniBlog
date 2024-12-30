using MiniBlog.Core.Contracts.Blogs.Queries.GetAllBlog;
using Zamin.Core.Contracts.ApplicationServices.Queries;

namespace MiniBlog.Core.Contracts.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQuery : IQuery<BlogDto>
    {
        public long Id { get; set; }
    }
}
