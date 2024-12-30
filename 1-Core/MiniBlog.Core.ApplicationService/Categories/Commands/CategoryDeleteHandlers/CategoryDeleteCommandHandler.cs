using MiniBlog.Core.Contracts.Blogs.BlogCategory.Queries;
using MiniBlog.Core.Contracts.Categories.Commands;
using MiniBlog.Core.Contracts.Categories.Commands.CategoryDelete;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;

namespace MiniBlog.Core.ApplicationService.Categories.Commands.CategoryDeleteHandlers
{
    public class CategoryDeleteCommandHandler : CommandHandler<CategoryDeleteCommand>
    {

        private readonly ICategoryCommandRepository _categoryCommandRepository;
        private readonly IBlogCategoryQueyRepository _blogCategoryQueyRepository;

        public CategoryDeleteCommandHandler(ZaminServices zaminServices,
                                        ICategoryCommandRepository categoryCommandRepository,
                                        IBlogCategoryQueyRepository blogCategoryQueyRepository) : base(zaminServices)
        {
            _categoryCommandRepository = categoryCommandRepository;
            _blogCategoryQueyRepository = blogCategoryQueyRepository;
        }

        public override async Task<CommandResult> Handle(CategoryDeleteCommand command)
        {
            //var blogCategory = await _blogCategoryQueyRepository.GetBlogCategoryById(command.CategoryId);
            //if (blogCategory == null) 
            //{
                //return ResultAsync(command.CategoryId, ApplicationServiceStatus.Exception);
                _categoryCommandRepository.Delete(command.CategoryId);
                await _categoryCommandRepository.CommitAsync();
                return await OkAsync();
            //}
            //return await OkAsync();
        }
    }
}
