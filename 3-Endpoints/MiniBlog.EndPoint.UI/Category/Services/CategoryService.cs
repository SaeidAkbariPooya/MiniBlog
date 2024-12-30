using MiniBlog.EndPoint.Shared.Models;
using MiniBlog.EndPoint.UI.Category.Models.Commands;
using MiniBlog.EndPoint.UI.Category.Models.Queries;

namespace MiniBlog.EndPoint.UI.Category.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryApi _categoryApi;
        public CategoryService(ICategoryApi categoryApi)
        {
            _categoryApi = categoryApi;
        }

        public Task<PagedData<CategoryModel>> GetAllAsync()
           => _categoryApi.GetAllAsync();

        public async Task<long> UpdateAsync(CategoryUpdateModel model)
           => await _categoryApi.Update(model);

        public async Task<long> CreateAsync(CategoryCreateModel model)
           => await _categoryApi.Create(model);

        public async Task<bool> DeleteAsync(long id)
           => await _categoryApi.DeleteAsync(id);

        public async Task<CategoryModel> GetByIdAsync(long model)
            => await _categoryApi.GetAsync(model);
    }
}
