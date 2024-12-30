using Microsoft.AspNetCore.Components;
using MiniBlog.EndPoint.UI.Photo.Models.Commands;
using MiniBlog.EndPoint.UI.Photo.Services;

namespace MiniBlog.EndPoint.UI.Photo.Component
{
    public partial class PhotoCreate
    {
        PhotoCreateModel model = new();
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IPhotoService photoService { get; set; }


        protected async Task Create()
        {
            await photoService.CreateAsync(model);
            NavigationManager.NavigateTo("/photos");
        }
    }
}
