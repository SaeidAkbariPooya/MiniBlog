using Zamin.Core.Domain.Entities;

namespace MiniBlog.Core.Domain.Blog.Entities
{
    public class BlogPhoto : Entity
    {
        #region Constructors
        private BlogPhoto()
        {
        }

        public BlogPhoto(long photoId)
        {
            PhotoId = photoId;
        }

        public BlogPhoto(long blogId, long photoId)
        {
            BlogId = blogId;
            PhotoId = photoId;
        }
        #endregion Constructors

        #region Properties
        public long BlogId { get; private set; }

        public long PhotoId { get; private set; }
        #endregion Properties

        #region Commands
        public static BlogPhoto Create(long blogId, long photoId) => new(blogId, photoId);
        public static BlogPhoto Create(long photoId) => new(photoId);
        #endregion Commands
    }
}
