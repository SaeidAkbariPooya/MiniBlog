using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace MiniBlog.Core.Contracts.Blogs.Commands.DeleteBlog
{
    public class BlogDeleteCommand : ICommand
    {
        public long BlogId { get; set; }
    }
}
