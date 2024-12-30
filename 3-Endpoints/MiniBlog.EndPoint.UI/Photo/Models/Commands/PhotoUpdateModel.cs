namespace MiniBlog.EndPoint.UI.Photo.Models.Commands
{
    public class PhotoUpdateModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; private set; }
    }
}
