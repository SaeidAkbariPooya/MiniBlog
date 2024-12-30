using MiniBlog.EndPoint.Shared.Models;
using MiniBlog.EndPoint.UI.Category.Models.Commands;
using MiniBlog.EndPoint.UI.Category.Models.Queries;
using Refit;

namespace MiniBlog.EndPoint.UI.Category.Services
{
    [Headers("Content-Type: application/json")]
    public interface ICategoryApi
    {
        [Get("/GetAll")]
        Task<PagedData<CategoryModel>> GetAllAsync();

        [Post("/Create")]
        Task<long> Create([Body] CategoryCreateModel command);

        [Put("/Update")]
        Task<long> Update([Body] CategoryUpdateModel model);

        [Get("/GetById/{id}")]
        Task<CategoryModel> GetAsync(long id);

        [Delete("/{id}")]
        Task<bool> DeleteAsync(long id);
    }
}
