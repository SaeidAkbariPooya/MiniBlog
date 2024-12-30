using MiniBlog.Core.Contracts.Categories.Queries.GetAllCategory;
using Zamin.Core.Contracts.ApplicationServices.Queries;

namespace MiniBlog.Core.Contracts.Categories.Queries.GetCategoryById
{
    public class GetCategoryByBusinessIdQuery : IQuery<CategoryDto>
    {
        public long CategoryId { get; set; }
    }
}
