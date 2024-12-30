using MiniBlog.Core.Contracts.Blogs.Queries.GetAllBlog;
using MiniBlog.Core.Contracts.Categories.Queries.GetAllCategory;
using MiniBlog.Core.Contracts.Photos.Queries.GetAllCategory;
using MiniBlog.Core.Contracts.Photos.Queries.GetAllPhoto;
using MiniBlog.Core.Contracts.Photos.Queries.GetPhotoById;
using Zamin.Core.Contracts.Data.Queries;

namespace MiniBlog.Core.Contracts.Photos.Queries
{
    public interface IPhotoQueryRepository
    {
        Task<PhotoDto> GetById(long Id);
        Task<PhotoDto> Execute(GetPhotoByIdQuery query);
        public PagedData<PhotoDto> Execute(GetAllPhotoQuery query);
    }
}
