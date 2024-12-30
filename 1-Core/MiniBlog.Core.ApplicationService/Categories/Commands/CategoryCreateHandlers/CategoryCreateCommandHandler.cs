using MiniBlog.Core.Contracts.Categories.Commands;
using MiniBlog.Core.Contracts.Categories.Commands.CategoryCreate;
using MiniBlog.Core.Domain.Categories.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;

namespace MiniBlog.Core.ApplicationService.Categories.Commands.CategoryCreateHandlers
{
    public class CategoryCreateCommandHandler : CommandHandler<CategoryCreateCommand, long>
    {
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        public CategoryCreateCommandHandler(ZaminServices zaminServices,
                                 ICategoryCommandRepository categoryCommandRepository) : base(zaminServices)
        {
            _categoryCommandRepository = categoryCommandRepository;
        }
        public override async Task<CommandResult<long>> Handle(CategoryCreateCommand command)
        {
            var category = Category.Create(command.Title);
            await _categoryCommandRepository.InsertAsync(category);
            await _categoryCommandRepository.CommitAsync();
            return Ok(category.Id);
        }
    }
}
