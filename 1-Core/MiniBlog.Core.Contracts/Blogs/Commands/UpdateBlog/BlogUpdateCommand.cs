using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace MiniBlog.Core.Contracts.Blogs.Commands.UpdateBlog
{
    public class BlogUpdateCommand : ICommand<long>
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        //public IList<Domain.Blog.Entities.BlogCategory> BlogCategories { get; set; }

        //public IList<Domain.Blog.Entities.BlogPhoto> BlogPhotos { get; set; }

        public List<long> BlogCategories { get; set; }

        public List<long> BlogPhotos { get; set; }
    }
}
