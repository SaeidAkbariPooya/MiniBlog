using Microsoft.AspNetCore.Mvc;
using MiniBlog.Core.Contracts.Photos.Commands.CategoryPhoto;
using MiniBlog.Core.Contracts.Photos.Commands.PhotoDelete;
using MiniBlog.Core.Contracts.Photos.Commands.PhotoUpdate;
using Zamin.EndPoints.Web.Controllers;

namespace MiniBlog.Endpoints.API.Photos
{
    [Route("api/Photo")]
    public class PhotoCommandController : BaseController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] PhotoCreateCommand command)
     => await Create<PhotoCreateCommand, long>(command);

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        => await Delete(new PhotoDeleteCommand { PhotoId = id });

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] PhotoUpdateCommand command)
    => await Edit<PhotoUpdateCommand, long>(command);
    }
}
