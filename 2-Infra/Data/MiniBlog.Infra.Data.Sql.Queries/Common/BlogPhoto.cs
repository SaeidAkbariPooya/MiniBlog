namespace MiniPerson.Infra.Data.Sql.Queries.Common;

public partial class BlogPhoto
{
    public long Id { get; set; }

    public long BlogId { get; set; }

    public long PhotoId { get; set; }

    public Blog Blog { get; set; }

    public Photo Photo { get; set; }

    public string? CreatedByUserId { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public string? ModifiedByUserId { get; set; }

    public DateTime? ModifiedDateTime { get; set; }

    public Guid BusinessId { get; set; }
}
