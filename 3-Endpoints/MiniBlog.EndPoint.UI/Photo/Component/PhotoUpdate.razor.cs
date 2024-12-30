using Microsoft.AspNetCore.Components;
using MiniBlog.EndPoint.UI.Category.Models.Commands;
using MiniBlog.EndPoint.UI.Category.Models.Queries;
using MiniBlog.EndPoint.UI.Category.Services;
using MiniBlog.EndPoint.UI.Photo.Component.Queries;
using MiniBlog.EndPoint.UI.Photo.Models.Commands;
using MiniBlog.EndPoint.UI.Photo.Services;

namespace MiniBlog.EndPoint.UI.Photo.Component
{
    public partial class PhotoUpdate
    {
        [Parameter]
        public string PhotoId { get; set; }

        PhotoUpdateModel model = new();
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IPhotoService photoService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (long.TryParse(PhotoId, out long id) == false) return;
            var photo = await photoService.GetByIdAsync(id);
            MapToModel(photo);
        }

        private void MapToModel(PhotoModel photo)
        {
            model.Id = photo.Id;
            model.Title = photo.Title;
            model.ImageUrl = photo.ImageUrl;
        }

        protected async Task Update()
        {
            await photoService.UpdateAsync(model);
            NavigationManager.NavigateTo("/photos");
        }
    }
}
