using Microsoft.AspNetCore.Components;
using MiniBlog.EndPoint.UI.Blog.Models.Commands;
using MiniBlog.EndPoint.UI.Blog.Models.Queries;
using MiniBlog.EndPoint.UI.Blog.Services;
using MiniBlog.EndPoint.UI.Category.Models.Queries;
using MiniBlog.EndPoint.UI.Category.Services;
using MiniBlog.EndPoint.UI.Photo.Component.Queries;
using MiniBlog.EndPoint.UI.Photo.Services;

namespace MiniBlog.EndPoint.UI.Blog.Component
{
    public partial class BlogUpdate
    {
        [Parameter]
        public string BlogId { get; set; }
        List<CategoryModel> categories = new();
        List<PhotoModel> photos = new();

        BlogUpdateModel model = new();
        string ErrorMessage;
        string[] SelectedCategories { get; set; } = Array.Empty<string>();
        string[] SelectedPhotos { get; set; } = Array.Empty<string>();

        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IBlogService NewsService { get; set; }
        [Inject] ICategoryService categoryService { get; set; }
        [Inject] IPhotoService photoService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (long.TryParse(BlogId, out long id) == false) return;
            var newsResult = await NewsService.GetByIdAsync(id);
                MapToModel(newsResult);

            var result = await categoryService.GetAllAsync();
                categories = result.QueryResult;

            var result1 = await photoService.GetAllAsync();
                photos = result1.QueryResult;
        }

        private void MapToModel(BlogModel blog)
        {
            model.Id = blog.Id;
            model.Title = blog.Title;
            model.Description = blog.Description;
            SelectedCategories = blog.BlogCategoeries.Select(s => s.BlogId.ToString())
                .ToArray();
            SelectedPhotos = blog.BlogPhotos.Select(s => s.PhotoId.ToString())
                .ToArray();
        }

        protected async Task Update()
        {
            model.BlogCategories = SelectedCategories.Select(x => Convert.ToInt64(x))
                .ToArray();
            model.BlogPhotos = SelectedCategories.Select(x => Convert.ToInt64(x))
                .ToArray();
            var result = await NewsService.UpdateAsync(model);
            NavigationManager.NavigateTo("/blogs");
        }
    }
}
