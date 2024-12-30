
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Common;
using Zamin.Utilities;
using MiniBlog.Core.Contracts.Photos.Commands.PhotoUpdate;
using MiniBlog.Core.Contracts.Photos.Commands;

namespace MiniBlog.Core.ApplicationService.Photos.Commands.PhotoUpdateHandler
{
    public class PhotoUpdateCommandHandler : CommandHandler<PhotoUpdateCommand, long>
    {
        private readonly IPhotoCommandRepository _photoCommandRepository;

        public PhotoUpdateCommandHandler(ZaminServices zaminServices,
                                    IPhotoCommandRepository photoCommandRepository) : base(zaminServices)
        {
            _photoCommandRepository = photoCommandRepository;
        }

        public override async Task<CommandResult<long>> Handle(PhotoUpdateCommand command)
        {
            var photo = await _photoCommandRepository.GetGraphAsync(command.Id);
            if (photo == null)
                return await ResultAsync(command.Id, ApplicationServiceStatus.NotFound);

            photo.PhotoUpdate(command.Title,command.ImageUrl);
            await _photoCommandRepository.CommitAsync();
            return Ok(photo.Id);
        }
    }
}
