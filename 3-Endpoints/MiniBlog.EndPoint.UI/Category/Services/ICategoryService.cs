using MiniBlog.EndPoint.Shared.Models;
using MiniBlog.EndPoint.UI.Category.Models.Commands;
using MiniBlog.EndPoint.UI.Category.Models.Queries;

namespace MiniBlog.EndPoint.UI.Category.Services
{
    public interface ICategoryService
    {
        Task<PagedData<CategoryModel>> GetAllAsync();
        Task<long> CreateAsync(CategoryCreateModel model);
        Task<long> UpdateAsync(CategoryUpdateModel model);
        Task<bool> DeleteAsync(long id);
        Task<CategoryModel> GetByIdAsync(long id);
    }
}
