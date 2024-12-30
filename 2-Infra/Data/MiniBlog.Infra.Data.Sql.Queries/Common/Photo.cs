namespace MiniPerson.Infra.Data.Sql.Queries.Common;

public partial class Photo
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }

    public string? CreatedByUserId { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public string? ModifiedByUserId { get; set; }

    public DateTime? ModifiedDateTime { get; set; }

    public Guid BusinessId { get; set; }

    public ICollection<BlogPhoto> BlogPhotos { get; set; }
}
