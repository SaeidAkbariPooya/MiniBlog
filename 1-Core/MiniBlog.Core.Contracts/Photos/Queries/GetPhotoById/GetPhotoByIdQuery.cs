using MiniBlog.Core.Contracts.Photos.Queries.GetAllCategory;
using Zamin.Core.Contracts.ApplicationServices.Queries;

namespace MiniBlog.Core.Contracts.Photos.Queries.GetPhotoById
{
    public class GetPhotoByIdQuery : IQuery<PhotoDto>
    {
        public long PhotoId { get; set; }
    }
}
