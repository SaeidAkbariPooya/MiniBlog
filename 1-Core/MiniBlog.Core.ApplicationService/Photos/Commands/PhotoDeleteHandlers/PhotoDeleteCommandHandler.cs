using MiniBlog.Core.Contracts.Photos.Commands;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;
using MiniBlog.Core.Contracts.Photos.Commands.PhotoDelete;
using MiniBlog.Core.Contracts.Blogs.BlogPhoto.Queries;


namespace MiniBlog.Core.ApplicationService.Photos.Commands.PhotoDeleteHandlers
{
    public class PhotoDeleteCommandHandler : CommandHandler<PhotoDeleteCommand>
    {

        private readonly IPhotoCommandRepository _photoCommandRepository;
        private readonly IBlogPhotoQueyRepository _blogPhotoQuerydRepository;

        public PhotoDeleteCommandHandler(ZaminServices zaminServices,
                                        IPhotoCommandRepository photoCommandRepository,
                                        IBlogPhotoQueyRepository blogPhotoQuerydRepository) : base(zaminServices)
        {
            _photoCommandRepository = photoCommandRepository;
            _blogPhotoQuerydRepository = blogPhotoQuerydRepository;
        }

        public override async Task<CommandResult> Handle(PhotoDeleteCommand command)
        {
            //var blogPhoto = await _blogPhotoQuerydRepository.GetBlogPhotoById(command.PhotoId);
            //if (blogPhoto == null)
            //{
            _photoCommandRepository.Delete(command.PhotoId);
            await _photoCommandRepository.CommitAsync();
            return await OkAsync();
            //return await OkAsync;
            //}
            //return Ok(false);
        }

    }
}
