using MiniBlog.EndPoint.Shared.Models;
using MiniBlog.EndPoint.UI.Blog.Models.Commands;
using MiniBlog.EndPoint.UI.Blog.Models.Queries;

namespace MiniBlog.EndPoint.UI.Blog.Services
{
    public interface IBlogService
    {
        Task<PagedData<BlogModel>> GetAllAsync();
        Task<long> CreateAsync(BlogCreateModel model);
        Task<long> UpdateAsync(BlogUpdateModel model);
        Task<bool> DeleteAsync(long id);
        Task<BlogModel> GetByIdAsync(long id);
    }
}
