using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Utilities;
using MiniBlog.Core.Contracts.Photos.Queries.GetAllCategory;
using MiniBlog.Core.Contracts.Photos.Queries;
using MiniBlog.Core.Contracts.Photos.Queries.GetPhotoById;

namespace MiniBlog.Core.ApplicationService.Photos.Queries.GetPhotoById
{
    public class GetPhotoByIdQueryHandler : QueryHandler<GetPhotoByIdQuery, PhotoDto>
    {
        private readonly IPhotoQueryRepository _photoQueryRepository;
        public GetPhotoByIdQueryHandler(ZaminServices zaminServices, IPhotoQueryRepository photoQueryRepository) : base(zaminServices)
        {
            _photoQueryRepository = photoQueryRepository;
        }
        public override async Task<QueryResult<PhotoDto>> Handle(GetPhotoByIdQuery query)
        {
            return Result(await _photoQueryRepository.GetById(query.PhotoId));
        }
    }
}
