using MiniBlog.EndPoint.Shared.Models;
using MiniBlog.EndPoint.UI.Category.Services;
using MiniBlog.EndPoint.UI.Photo.Component.Queries;
using MiniBlog.EndPoint.UI.Photo.Models.Commands;
using System.Reflection;

namespace MiniBlog.EndPoint.UI.Photo.Services
{
    public class PhotoService : IPhotoService
    {
        IPhotoApi _photoApi;
        public PhotoService(IPhotoApi photoApi)
        {
            _photoApi = photoApi;
        }

        public async Task<long> CreateAsync(PhotoCreateModel model)
             => await _photoApi.Create(model);

        public async Task<bool> DeleteAsync(long id)
             => await _photoApi.DeleteAsync(id);

        public Task<PagedData<PhotoModel>> GetAllAsync()
             => _photoApi.GetAllAsync();

        public async Task<PhotoModel> GetByIdAsync(long id)
             => await _photoApi.GetAsync(id);

        public async Task<long> UpdateAsync(PhotoUpdateModel model)
             => await _photoApi.Update(model);
    }
}
