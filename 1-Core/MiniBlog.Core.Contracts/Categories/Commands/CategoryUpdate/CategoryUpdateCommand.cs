using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace MiniBlog.Core.Contracts.Categories.Commands.CategoryUpdate
{
    public class CategoryUpdateCommand : ICommand<long>
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }
}
