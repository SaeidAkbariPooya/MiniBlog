using Zamin.Core.Domain.Entities;

namespace MiniBlog.Core.Domain.Photos.Entities
{
    public class Photo : AggregateRoot
    {
        #region Field
        public string Title { get; private set; }
        public string ImageUrl { get; private set; }

        #endregion

        #region Constructor 
        private Photo()
        {
        }

        public Photo(string imageUrl, string title)
        {
            ImageUrl = imageUrl;
            Title = title;
        }

        public void PhotoUpdate(string title, string imageUrl)
        {
            ImageUrl = imageUrl;
            Title = title;
        }
        #endregion

        #region Command
        public static Photo Create(string imageUrl,string title) => new(imageUrl,title);
        #endregion Command
    }
}
