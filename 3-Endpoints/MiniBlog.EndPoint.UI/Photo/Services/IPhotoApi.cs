using MiniBlog.EndPoint.Shared.Models;
using MiniBlog.EndPoint.UI.Category.Models.Commands;
using MiniBlog.EndPoint.UI.Category.Models.Queries;
using MiniBlog.EndPoint.UI.Photo.Component.Queries;
using MiniBlog.EndPoint.UI.Photo.Models.Commands;
using Refit;

namespace MiniBlog.EndPoint.UI.Photo.Services
{
    public interface IPhotoApi
    {
        [Get("/GetAll")]
        Task<PagedData<PhotoModel>> GetAllAsync();

        [Post("/Create")]
        Task<long> Create([Body] PhotoCreateModel command);

        [Put("/Update")]
        Task<long> Update([Body] PhotoUpdateModel model);

        [Get("/GetById/{id}")]
        Task<PhotoModel> GetAsync(long id);

        [Delete("/{id}")]
        Task<bool> DeleteAsync(long id);
    }
}
