using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace MiniBlog.Core.Contracts.Blogs.Commands.CreateBlog
{
    public class BlogCreateCommand : ICommand<long>
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        //public IList<long> BlogCategories { get; set; }

        //public IList<long> BlogPhotos { get; set; }

        public long[] CategoryIds { get; set; }
        public long[] ImageIds { get; set; }
    }
}
