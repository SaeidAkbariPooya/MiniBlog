using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Toolkits.ValueObjects;

namespace MiniBlog.Core.Domain.Blog.Entities
{
    public class Blog : AggregateRoot
    {
        #region Constructors
        private Blog()
        { }

        public Blog(Title title, Description description)
        {
            Title = title;
            Description = description;
        }
        public Blog(Title title, Description description, long[] categories, long[] photos)
        {
            Title = title;
            Description = description;

            _BlogCategories = categories.Select(x => BlogCategory.Create(x)).ToList();
            _BlogPhoto = photos.Select(x => BlogPhoto.Create(x)).ToList();
        }
        #endregion Constructors

        #region Properties
        public Title Title { get; private set; }

        public Description Description { get; private set; }

        public IReadOnlyList<BlogCategory> _BlogCategories { get; private set; }
        public IReadOnlyList<BlogPhoto> _BlogPhoto { get; private set; }
        #endregion Properties

        #region Command
        public static Blog Create(Title title, Description description, long[] categoryIds, long[] imageIds)
            => new(title, description, categoryIds, imageIds);

        public void BlogUpdate(Title title, Description description, List<long> categories, List<long> photos)
        {
            Title = title;
            Description = description;


            _BlogCategories = categories.Select(x => BlogCategory.Create(x)).ToList();

            _BlogPhoto = photos.Select(x => BlogPhoto.Create(x)).ToList();
        }

        #endregion Command

        #region Methods
        //public void AddBlogCategories(IList<BlogCategory> blogCategories)
        //{
        //    _blogCategories.AddRange(blogCategories);
        //}
        //public void AddBlogCategory(BlogCategory blogCategory)
        //{
        //    _blogCategories.Add(blogCategory);
        //}
        //public void AddBlogPhotos(IList<BlogPhoto> bloghotos)
        //{
        //    _blogPhotos.AddRange(bloghotos);
        //}
        #endregion Methods
    }
}
