using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace MiniBlog.Core.Contracts.Categories.Commands.CategoryCreate
{
    public class CategoryCreateCommand : ICommand<long>
    {
        public string Title { get; set; }
    }
}
