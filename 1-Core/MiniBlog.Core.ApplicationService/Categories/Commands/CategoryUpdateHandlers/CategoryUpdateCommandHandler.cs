using MiniBlog.Core.Contracts.Categories.Commands;
using MiniBlog.Core.Contracts.Categories.Commands.CategoryUpdate;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Common;
using Zamin.Utilities;

namespace MiniBlog.Core.ApplicationService.Categories.Commands.CategoryUpdateHandlers
{
    public class CategoryUpdateCommandHandler : CommandHandler<CategoryUpdateCommand, long>
    {
        private readonly ICategoryCommandRepository _categoryCommandRepository;

        public CategoryUpdateCommandHandler(ZaminServices zaminServices,
                                    ICategoryCommandRepository categoryCommandRepository) : base(zaminServices)
        {
            _categoryCommandRepository = categoryCommandRepository;
        }

        public override async Task<CommandResult<long>> Handle(CategoryUpdateCommand command)
        {
            var category = await _categoryCommandRepository.GetGraphAsync(command.Id);
            if (category == null)
                return await ResultAsync(command.Id, ApplicationServiceStatus.NotFound);

            category.CategoryUpdate(command.Title);
            await _categoryCommandRepository.CommitAsync();
            return Ok(category.Id);
        }
    }
}
