using MiniBlog.Core.Contracts.Categories.Commands;
using MiniBlog.Core.Domain.Categories.Entities;
using MiniBlog.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace MiniPerson.Infra.Data.Sql.Commands.Categories
{
    public class CategoryCommandRepository : BaseCommandRepository<Category, MiniBlogCommandDbContext>,
        ICategoryCommandRepository
    {
        public CategoryCommandRepository(MiniBlogCommandDbContext dbContext) : base(dbContext)
        {
        }

    }
}
