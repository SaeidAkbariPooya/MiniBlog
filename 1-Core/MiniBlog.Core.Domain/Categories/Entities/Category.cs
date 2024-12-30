using Zamin.Core.Domain.Entities;

namespace MiniBlog.Core.Domain.Categories.Entities
{
    public class Category : AggregateRoot
    {
        #region Field
        public string Title { get; private set; }
        
        #endregion

        #region Constructor 
        private Category()
        {

        }
        public Category(string title)
        {
            Title = title;
        }

        public void CategoryUpdate(string title)
        {
            Title = title;
        }
        #endregion

        #region Command
        public static Category Create(string title) => new(title);
        #endregion
    }
}
