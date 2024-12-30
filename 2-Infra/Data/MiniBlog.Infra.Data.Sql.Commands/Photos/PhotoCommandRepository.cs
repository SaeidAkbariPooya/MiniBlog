using MiniBlog.Core.Contracts.Photos.Commands;
using MiniBlog.Core.Domain.Photos.Entities;
using MiniBlog.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace MiniBlog.Infra.Data.Sql.Commands.Photos
{
    public class PhotoCommandRepository : BaseCommandRepository<Photo, MiniBlogCommandDbContext>,
        IPhotoCommandRepository
    {
        public PhotoCommandRepository(MiniBlogCommandDbContext dbContext) : base(dbContext)
        {
        }

    }
}
