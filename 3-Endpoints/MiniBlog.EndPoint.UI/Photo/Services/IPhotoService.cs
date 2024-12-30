using MiniBlog.EndPoint.Shared.Models;
using MiniBlog.EndPoint.UI.Category.Models.Commands;
using MiniBlog.EndPoint.UI.Category.Models.Queries;
using MiniBlog.EndPoint.UI.Photo.Component.Queries;
using MiniBlog.EndPoint.UI.Photo.Models.Commands;

namespace MiniBlog.EndPoint.UI.Photo.Services
{
    public interface IPhotoService
    {
        Task<PagedData<PhotoModel>> GetAllAsync();
        Task<long> CreateAsync(PhotoCreateModel model);
        Task<long> UpdateAsync(PhotoUpdateModel model);
        Task<bool> DeleteAsync(long id);
        Task<PhotoModel> GetByIdAsync(long id);
    }
}
