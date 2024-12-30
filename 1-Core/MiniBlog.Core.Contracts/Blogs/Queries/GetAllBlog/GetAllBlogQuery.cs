using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;

namespace MiniBlog.Core.Contracts.Blogs.Queries.GetAllBlog
{
    public class GetAllBlogQuery : PageQuery<PagedData<BlogDto>>
    {
    }
}
