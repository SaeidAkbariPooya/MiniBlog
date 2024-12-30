namespace MiniBlog.EndPoint.UI.Blog.Models.Commands
{
    public class BlogUpdateModel
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public long[] BlogCategories { get; set; }

        public long[] BlogPhotos { get; set; }
    }
}
