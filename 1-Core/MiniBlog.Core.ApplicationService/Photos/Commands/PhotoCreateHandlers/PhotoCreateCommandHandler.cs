using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;
using MiniBlog.Core.Contracts.Photos.Commands;
using MiniBlog.Core.Domain.Photos.Entities;
using MiniBlog.Core.Contracts.Photos.Commands.CategoryPhoto;

namespace MiniBlog.Core.ApplicationService.Photos.Commands.PhotoCreateHandlers
{
    public class PhotoCreateCommandHandler : CommandHandler<PhotoCreateCommand, long>
    {
        private readonly IPhotoCommandRepository _photoCommandRepository;
        public PhotoCreateCommandHandler(ZaminServices zaminServices,
                                         IPhotoCommandRepository photoCommandRepository) : base(zaminServices)
        {
            _photoCommandRepository = photoCommandRepository;
        }
        public override async Task<CommandResult<long>> Handle(PhotoCreateCommand command)
        {
            var photo = Photo.Create(command.ImageUrl,command.Title);
            await _photoCommandRepository.InsertAsync(photo);
            await _photoCommandRepository.CommitAsync();
            return Ok(photo.Id);
        }
    }
}
