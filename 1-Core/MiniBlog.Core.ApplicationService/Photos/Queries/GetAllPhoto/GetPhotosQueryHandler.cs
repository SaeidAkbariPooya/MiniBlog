using MiniBlog.Core.Contracts.Photos.Queries;
using MiniBlog.Core.Contracts.Photos.Queries.GetAllCategory;
using MiniBlog.Core.Contracts.Photos.Queries.GetAllPhoto;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Utilities;

namespace MiniBlog.Core.ApplicationService.Photos.Queries.GetAllPhoto
{
    public class GetPhotosQueryHandler : QueryHandler<GetAllPhotoQuery, PagedData<PhotoDto>>
    {
        private readonly IPhotoQueryRepository _photoQueryRepository;
        public GetPhotosQueryHandler(ZaminServices zaminServices,
                                            IPhotoQueryRepository photoQueryRepository) : base(zaminServices)
        {
            _photoQueryRepository = photoQueryRepository;
        }
        public override async Task<QueryResult<PagedData<PhotoDto>>> Handle(GetAllPhotoQuery query)
        {
            try
            {
                var result = _photoQueryRepository.Execute(query);

                return Result(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
