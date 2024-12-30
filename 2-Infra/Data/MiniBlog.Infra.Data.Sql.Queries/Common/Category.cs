namespace MiniPerson.Infra.Data.Sql.Queries.Common
{
    public partial class Category
    {
        public long Id { get; set; }
        public string Title { get; private set; }
        //public string CategoryName { get; set; } = null!;
        public string? CreatedByUserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string? ModifiedByUserId { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public Guid BusinessId { get; set; }
        public ICollection<BlogCategory> BlogCategories { get; set; }
    }
}
