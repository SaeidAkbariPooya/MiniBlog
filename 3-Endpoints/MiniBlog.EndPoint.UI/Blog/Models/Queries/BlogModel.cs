namespace MiniBlog.EndPoint.UI.Blog.Models.Queries
{
    public class BlogModel
    {
        public long Id { get; set; }

        public Guid BusinessId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IList<BlogPhotoQr> BlogPhotos { get; set; }
        public IList<BlogCategoeryQr> BlogCategoeries { get; set; }
    }

    public class BlogPhotoQr
    {
        public long PhotoId { get; set; }
        public long BlogId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }

    public class BlogCategoeryQr
    {
        public long CategoryId { get; set; }

        public long BlogId { get; set; }

        public string Title { get; set; } = string.Empty;
    }
}
