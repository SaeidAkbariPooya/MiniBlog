namespace MiniPerson.Infra.Data.Sql.Queries.Common;

public partial class BlogCategory
{
    public long Id { get; set; }

    public long BlogId { get; set; }

    public long CategoryId { get; set; }
    public string? CreatedByUserId { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public string? ModifiedByUserId { get; set; }

    public DateTime? ModifiedDateTime { get; set; }

    public Guid BusinessId { get; set; }

    public Blog Blog { get; set; }

    public Category Category { get; set; }
}
