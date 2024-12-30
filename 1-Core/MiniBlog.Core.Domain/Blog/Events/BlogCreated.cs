using MiniBlog.Core.Domain.Blog.Entities;
using Zamin.Core.Domain.Events;

namespace MiniBlog.Core.Domain.Blog.Events
{
    public class BlogCreated :IDomainEvent
    {
        private BlogCreated()
        {

        }
        public BlogCreated(string businessId, string title, string description)
        {
            BusinessId = businessId;
            Title = title;
            Description = description;
        }
        public BlogCreated(string businessId, string title, string description, IList<BlogPhoto> photos, IList<BlogCategory> categories)
        {
            BusinessId = businessId;
            Title = title;
            Description = description;
            Photos = photos;
            Categories = categories;
        }

        public string BusinessId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public IList<BlogPhoto> Photos { get; private set; }
        public IList<BlogCategory> Categories { get; private set; }
    }
}
