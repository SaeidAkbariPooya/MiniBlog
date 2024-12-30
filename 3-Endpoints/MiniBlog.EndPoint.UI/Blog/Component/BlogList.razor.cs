using Microsoft.AspNetCore.Components;
using MiniBlog.EndPoint.Shared.Models;
using MiniBlog.EndPoint.UI.Blog.Models.Queries;
using MiniBlog.EndPoint.UI.Blog.Services;

namespace MiniBlog.EndPoint.UI.Blog.Component
{
    public partial class BlogList
    {
        private long counter = 1;
        private PagedData<BlogModel> pagedData;
        [Inject] IBlogService blogService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            pagedData = await blogService.GetAllAsync();
        }

        private async Task Delete(long id)
        {
            var result = await blogService.DeleteAsync(id);
            //if (result == false)
            //    ErrorMessage = result.ErrorMessage;
            //else
            await LoadDataAsync();
        }
    }
}
