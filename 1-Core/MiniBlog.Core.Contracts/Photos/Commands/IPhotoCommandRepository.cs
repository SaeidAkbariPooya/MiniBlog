using MiniBlog.Core.Domain.Photos.Entities;
using Zamin.Core.Contracts.Data.Commands;

namespace MiniBlog.Core.Contracts.Photos.Commands
{
    public interface IPhotoCommandRepository : ICommandRepository<Photo>
    {
    }
}
