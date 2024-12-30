using MiniBlog.Core.Contracts.Blogs.Commands;
using MiniBlog.Core.Contracts.Blogs.Commands.CreateBlog;
using MiniBlog.Core.Domain.Blog.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;

namespace MiniBlog.Core.ApplicationService.Blogs.Commands.BlogCreateHandlers
{
    public class BlogCreateCommandHandler : CommandHandler<BlogCreateCommand, long>
    {
        private readonly IBlogCommandRepository _blogCommandRepository;

        public BlogCreateCommandHandler(ZaminServices zaminServices,
                                        IBlogCommandRepository blogCommandRepository)
                                        : base(zaminServices)
        {
            _blogCommandRepository = blogCommandRepository;
        }

        public override async Task<CommandResult<long>> Handle(BlogCreateCommand command)
        {
            Blog news = Blog.Create(command.Title,command.Description,
                                    command.CategoryIds, command.ImageIds);
            await _blogCommandRepository.InsertAsync(news);
            await _blogCommandRepository.CommitAsync();
            return Ok(news.Id);
        }
    }
}
