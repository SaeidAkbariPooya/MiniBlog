using MiniBlog.Core.Contracts.Blogs.Commands;
using MiniBlog.Core.Contracts.Blogs.Commands.DeleteBlog;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;

namespace MiniBlog.Core.ApplicationService.Blogs.Commands.BlogDeleteHandlers
{
    public class BlogDeleteCommandHandler : CommandHandler<BlogDeleteCommand>
    {
        private readonly IBlogCommandRepository _blogCommandRepository;

        public BlogDeleteCommandHandler(ZaminServices zaminServices,
                                        IBlogCommandRepository blogCommandRepository)
                                        : base(zaminServices)
        {
            _blogCommandRepository = blogCommandRepository;
        }
        public override async Task<CommandResult> Handle(BlogDeleteCommand command)
        {
            _blogCommandRepository.DeleteGraph(command.BlogId);
            await _blogCommandRepository.CommitAsync();
            return await OkAsync();
        }
    }
}
