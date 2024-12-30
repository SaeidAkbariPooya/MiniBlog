using MiniBlog.Core.Domain.Categories.Entities;
using Zamin.Core.Contracts.Data.Commands;

namespace MiniBlog.Core.Contracts.Categories.Commands
{
    public interface ICategoryCommandRepository : ICommandRepository<Category>
    {
    }
}
