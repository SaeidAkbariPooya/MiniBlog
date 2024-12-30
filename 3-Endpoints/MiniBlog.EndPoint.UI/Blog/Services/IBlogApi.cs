using MiniBlog.EndPoint.Shared.Models;
using MiniBlog.EndPoint.UI.Blog.Models.Commands;
using MiniBlog.EndPoint.UI.Blog.Models.Queries;
using Refit;

namespace MiniBlog.EndPoint.UI.Blog.Services
{
    [Headers("Content-Type: application/json")]
    public interface IBlogApi
    {
        [Get("/GetAll")]
        Task<PagedData<BlogModel>> GetAllAsync();

        [Post("/Create")]
        Task<long> Create([Body] BlogCreateModel command);

        [Put("/Update")]
        Task<long> Update([Body] BlogUpdateModel model);

        [Get("/GetById/{id}")]
        Task<BlogModel> GetAsync(long id);

        [Delete("/{id}")]
        Task<bool> DeleteAsync(long id);
    }
}
