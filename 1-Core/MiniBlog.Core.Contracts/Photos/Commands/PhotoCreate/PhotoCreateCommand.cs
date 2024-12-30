using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace MiniBlog.Core.Contracts.Photos.Commands.CategoryPhoto
{
    public class PhotoCreateCommand : ICommand<long>
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; private set; }
    }
}
