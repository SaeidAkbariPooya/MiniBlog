using MiniBlog.EndPoint.Shared.Models;
using MiniBlog.EndPoint.UI.Blog.Models.Commands;
using MiniBlog.EndPoint.UI.Blog.Models.Queries;

namespace MiniBlog.EndPoint.UI.Blog.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogApi _blogApi;
        public BlogService(IBlogApi blogApi)
        {
            _blogApi = blogApi;
        }
        public async Task<long> CreateAsync(BlogCreateModel model)
            => await _blogApi.Create(model);

        public async Task<bool> DeleteAsync(long id)
            => await _blogApi.DeleteAsync(id);

        public Task<PagedData<BlogModel>> GetAllAsync()
            => _blogApi.GetAllAsync();

        public async Task<BlogModel> GetByIdAsync(long id)
            => await _blogApi.GetAsync(id);

        public async Task<long> UpdateAsync(BlogUpdateModel model)
            => await _blogApi.Update(model);
    }
}
