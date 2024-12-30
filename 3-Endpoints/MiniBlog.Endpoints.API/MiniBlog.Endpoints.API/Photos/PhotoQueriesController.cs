using Microsoft.AspNetCore.Mvc;
using MiniBlog.Core.Contracts.Photos.Queries.GetAllCategory;
using MiniBlog.Core.Contracts.Photos.Queries.GetAllPhoto;
using MiniBlog.Core.Contracts.Photos.Queries.GetPhotoById;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.EndPoints.Web.Controllers;

namespace MiniBlog.Endpoints.API.Photos
{
    [Route("api/Photo")]
    public class PhotoQueriesController : BaseController
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(GetAllPhotoQuery query)
              => await Query<GetAllPhotoQuery, PagedData<PhotoDto>>(query);

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(long id)
                             => await Query<GetPhotoByIdQuery, PhotoDto>(new GetPhotoByIdQuery { PhotoId = id});
    }
}
