using MiniBlog.Core.Contracts.Photos.Queries.GetAllCategory;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;

namespace MiniBlog.Core.Contracts.Photos.Queries.GetAllPhoto
{
    public class GetAllPhotoQuery : PageQuery<PagedData<PhotoDto>>
    {
    }
}
