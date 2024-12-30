using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace MiniBlog.Core.Contracts.Categories.Commands.CategoryDelete
{
    public class CategoryDeleteCommand : ICommand
    {
        public long CategoryId { get; set; }
    }
}
