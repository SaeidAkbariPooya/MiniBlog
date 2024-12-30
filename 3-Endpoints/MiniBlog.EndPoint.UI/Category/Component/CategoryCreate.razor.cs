using Microsoft.AspNetCore.Components;
using MiniBlog.EndPoint.UI.Category.Models.Commands;
using MiniBlog.EndPoint.UI.Category.Services;

namespace MiniBlog.EndPoint.UI.Category.Component
{
    public partial class CategoryCreate
    {
        CategoryCreateModel model = new();
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ICategoryService categoryService { get; set; }

        protected async Task Create()
        {
            await categoryService.CreateAsync(model);
            NavigationManager.NavigateTo("/categories");
        }
    }
}
