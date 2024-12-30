using Microsoft.EntityFrameworkCore;
using MiniBlog.Core.Contracts.Categories.Queries.GetAllCategory;
using MiniBlog.Core.Contracts.Categories.Queries.GetCategoryById;
using MiniBlog.Core.Contracts.Photos.Queries;
using MiniBlog.Core.Contracts.Photos.Queries.GetAllCategory;
using MiniBlog.Core.Contracts.Photos.Queries.GetAllPhoto;
using MiniBlog.Core.Contracts.Photos.Queries.GetPhotoById;
using MiniBlog.Infra.Data.Sql.Queries.Common;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Infra.Data.Sql.Queries;

namespace MiniBlog.Infra.Data.Sql.Queries.Photos
{
    public class PhotoQueryRepository : BaseQueryRepository<MiniBlogQueryDbContext>, IPhotoQueryRepository
    {
        public PhotoQueryRepository(MiniBlogQueryDbContext dbContext) : base(dbContext)
        {

        }

        public PagedData<PhotoDto> Execute(GetAllPhotoQuery getAllPhoto)
        {
            PagedData<PhotoDto> result = new();


            var query = _dbContext.Photos.AsNoTracking();

            result.QueryResult = query.OrderByDescending(c => c.Id).Skip(getAllPhoto.SkipCount)
                        .Take(getAllPhoto.PageSize)
                        .Select(c => new PhotoDto
                        {
                            Id = c.Id,
                            Title = c.Title,
                            ImageUrl = c.ImageUrl
                        }).ToList();


            if (getAllPhoto.NeedTotalCount)
            {
                result.TotalCount = query.Count();
            }

            return result;

        }

        public async Task<PhotoDto> Execute(GetPhotoByIdQuery query)
        => await _dbContext.Photos.Where(c => c.Id.Equals(query.PhotoId)).Select(c => new PhotoDto()
        {
            Id = c.Id,
            Title = c.Title,
            ImageUrl = c.ImageUrl
        }).FirstOrDefaultAsync();

        public async Task<PhotoDto> GetById(long Id)
        {
            var photo = await _dbContext.Photos
              .Select(c => new PhotoDto
              {
                  Id = c.Id,
                  //BusinessId = c.BusinessId,
                  ImageUrl = c.ImageUrl,
                  Title = c.Title
              })
              .FirstOrDefaultAsync(c => c.Id.Equals(Id));

            return photo;
        }
    }
}
