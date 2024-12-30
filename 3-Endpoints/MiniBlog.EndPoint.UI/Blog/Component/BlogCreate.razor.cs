using Microsoft.AspNetCore.Components;
using MiniBlog.EndPoint.UI.Blog.Models.Commands;
using MiniBlog.EndPoint.UI.Blog.Services;
using MiniBlog.EndPoint.UI.Category.Models.Queries;
using MiniBlog.EndPoint.UI.Category.Services;
using MiniBlog.EndPoint.UI.Photo.Component.Queries;
using MiniBlog.EndPoint.UI.Photo.Services;

namespace MiniBlog.EndPoint.UI.Blog.Component
{
    public partial class BlogCreate
    {
        BlogCreateModel model = new();
        List<CategoryModel> categories = new();
        List<PhotoModel> photos = new();
        string ErrorMessage;
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IBlogService blogService { get; set; }
        [Inject] ICategoryService categoryService { get; set; }
        [Inject] IPhotoService photoService { get; set; }

        public string[] SelectedCategories { get; set; } = Array.Empty<string>();
        public string[] SelectedPhotos { get; set; } = Array.Empty<string>();

        protected override async Task OnInitializedAsync()
        {
            var result = await categoryService.GetAllAsync();
            categories = result.QueryResult;

            var result1 = await photoService.GetAllAsync();
            photos = result1.QueryResult;
        }
        protected async Task Create()
        {
            model.CategoryIds = SelectedCategories.Select(x => Convert.ToInt64(x))
                .ToArray();

            model.ImageIds = SelectedCategories.Select(x => Convert.ToInt64(x))
               .ToArray();

            var result = await blogService.CreateAsync(model);
            NavigationManager.NavigateTo("/blogs");
        }
    }
}
