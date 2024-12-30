namespace MiniBlog.Core.Contracts.Blogs.Queries.GetAllBlog;

public class BlogDto
{
    public long Id { get; set; }

    public Guid BusinessId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public IList<BlogPhotoDto> BlogPhotos { get; set; }
    public IList<BlogCategoeryDto> BlogCategoeries { get; set; }
}

public class BlogPhotoDto
{
    public long PhotoId { get; set; }
    public long BlogId { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
}

public class BlogCategoeryDto
{
    public long CategoryId { get; set; }

    public long BlogId { get; set; }

    public string Title { get; set; } = string.Empty;
}