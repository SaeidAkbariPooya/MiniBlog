using Microsoft.AspNetCore.Components;
using MiniBlog.EndPoint.UI.Category.Models.Commands;
using MiniBlog.EndPoint.UI.Category.Models.Queries;
using MiniBlog.EndPoint.UI.Category.Services;

namespace MiniBlog.EndPoint.UI.Category.Component
{
    public partial class CategoryUpdate
    {
        [Parameter]
        public string CategoryId { get; set; }

        CategoryUpdateModel model = new();
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ICategoryService categoryService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (long.TryParse(CategoryId, out long id) == false) return;
            var category = await categoryService.GetByIdAsync(id);
            MapToModel(category);
        }

        private void MapToModel(CategoryModel category)
        {
            model.Id = category.Id;
            model.Title = category.Title;
        }

        protected async Task Update()
        {
            await categoryService.UpdateAsync(model);
            NavigationManager.NavigateTo("/categories");
        }
    }
}
