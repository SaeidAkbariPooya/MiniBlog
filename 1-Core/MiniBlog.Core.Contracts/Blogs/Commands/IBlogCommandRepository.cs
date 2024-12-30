using MiniBlog.Core.Domain.Blog.Entities;
using Zamin.Core.Contracts.Data.Commands;

namespace MiniBlog.Core.Contracts.Blogs.Commands
{
    public interface IBlogCommandRepository : ICommandRepository<Blog>
    {
        Task CreateBlogCategory(List<Domain.Blog.Entities.BlogCategory> blogCategories);
        Task CreateBlogPhoto(List<Domain.Blog.Entities.BlogPhoto> blogPhotos);
    }
}
