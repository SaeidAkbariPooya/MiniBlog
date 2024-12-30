using Microsoft.AspNetCore.Components;
using MiniBlog.EndPoint.Shared.Models;
using MiniBlog.EndPoint.UI.Photo.Component.Queries;
using MiniBlog.EndPoint.UI.Photo.Services;

namespace MiniBlog.EndPoint.UI.Photo.Component
{
    public partial class PhotoList
    {
        private PagedData<PhotoModel> pagedData;
        private string ErrorMessage;
        private long counter = 1;

        [Inject] IPhotoService photoService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            pagedData = await photoService.GetAllAsync();
        }

        private async Task Delete(long id)
        {
            var result = await photoService.DeleteAsync(id);
            if (result == false)
                ErrorMessage = "خطا";
            else
                await LoadDataAsync();
        }
    }
}
