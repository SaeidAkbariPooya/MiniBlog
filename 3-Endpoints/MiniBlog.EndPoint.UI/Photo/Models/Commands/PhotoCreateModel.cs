namespace MiniBlog.EndPoint.UI.Photo.Models.Commands
{
    public class PhotoCreateModel
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; private set; }
    }
}
