using MiniBlog.Core.Contracts.Blogs.Commands.UpdateBlog;
using MiniBlog.Core.Contracts.Categories.Commands.CategoryUpdate;
using MiniBlog.Core.Contracts.Categories.Commands;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Common;
using Zamin.Utilities;
using MiniBlog.Core.Contracts.Blogs.Commands;

namespace MiniBlog.Core.ApplicationService.Blogs.Commands.BlogUpdateHandlers
{
    public class BlogUpdateCommandHandler : CommandHandler<BlogUpdateCommand, long>
    {
        private readonly IBlogCommandRepository _blogCommandRepository;

        public BlogUpdateCommandHandler(ZaminServices zaminServices,
                                        IBlogCommandRepository blogCommandRepository) 
                                        : base(zaminServices)
        {
            _blogCommandRepository = blogCommandRepository;
        }

        public override async Task<CommandResult<long>> Handle(BlogUpdateCommand command)
        {
            var blog = await _blogCommandRepository.GetGraphAsync(command.Id);
            if (blog == null)
                return await ResultAsync(command.Id, ApplicationServiceStatus.NotFound);

            blog.BlogUpdate(command.Title,command.Description,command.BlogCategories,command.BlogPhotos);
            await _blogCommandRepository.CommitAsync();

            return Ok(blog.Id);
        }
    }
}
