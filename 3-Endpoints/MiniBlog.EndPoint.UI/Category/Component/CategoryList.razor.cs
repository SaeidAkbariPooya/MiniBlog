using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MiniBlog.EndPoint.Shared.Models;
using MiniBlog.EndPoint.UI.Category.Models.Queries;
using MiniBlog.EndPoint.UI.Category.Services;

namespace MiniBlog.EndPoint.UI.Category.Component
{
    public partial class CategoryList
    {
        private PagedData<CategoryModel> catList;
        private long DeleteId;
        private long counter = 1;

        bool showModal = false;

        void ModalShow() => showModal = true;
        void ModalCancel() => showModal = false;

        [Inject] ICategoryService categoryService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
        }
        private async Task LoadDataAsync()
        {
            catList = await categoryService.GetAllAsync();
        }

        async void ModalOk(long id)
        {
            showModal = true;
            DeleteId = id;
        }

        private async Task Delete()
        {
            showModal = false;
            await categoryService.DeleteAsync(DeleteId);
            await LoadDataAsync();
            //NavigationManager.NavigateTo("/categories");
        }
    }
}
