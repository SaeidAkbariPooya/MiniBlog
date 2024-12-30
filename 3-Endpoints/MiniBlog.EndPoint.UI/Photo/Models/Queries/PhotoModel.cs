namespace MiniBlog.EndPoint.UI.Photo.Component.Queries
{
    public class PhotoModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; private set; }
    }
}
