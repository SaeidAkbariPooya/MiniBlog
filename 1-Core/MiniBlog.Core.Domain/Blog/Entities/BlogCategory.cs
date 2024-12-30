using Zamin.Core.Domain.Entities;

namespace MiniBlog.Core.Domain.Blog.Entities
{
    public class BlogCategory : Entity
    {
        #region Constructors
        private BlogCategory()
        {
        }

        public BlogCategory(long categoryId)
        {
            CategoryId = categoryId;
        }

        public BlogCategory(long blogId, long categoryId)
        {
            BlogId = blogId;
            CategoryId = categoryId;
        }
        #endregion Constructors

        #region Properties
        public long BlogId { get; private set; }
        public long CategoryId { get; private set; }
        #endregion Properties

        #region Commands
        public static BlogCategory Create(long blogId, long categoryId) => new(blogId, categoryId);
        public static BlogCategory Create(long categoryId) => new(categoryId);
        #endregion Commands
    }
}
