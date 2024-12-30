namespace MiniBlog.EndPoint.UI.Blog.Models.Commands
{
    public class BlogCreateModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public long[] CategoryIds { get; set; }
        public long[] ImageIds { get; set; }
    }
}
