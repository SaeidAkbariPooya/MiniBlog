using Zamin.Core.Domain.ValueObjects;

namespace MiniBlog.Core.Contracts.Categories.Queries.GetAllCategory
{
    public class CategoryDto
    {
        public long Id { get; set; }
        public Guid BusinessId { get; set; }
        public string Title { get; set; }
        //public string CategoryName { get; set; }
    }
}
