using Microsoft.AspNetCore.Mvc;
using MiniBlog.Core.Contracts.Categories.Commands.CategoryCreate;
using MiniBlog.Core.Contracts.Categories.Commands.CategoryDelete;
using MiniBlog.Core.Contracts.Categories.Commands.CategoryUpdate;
using Zamin.EndPoints.Web.Controllers;

namespace MiniBlog.Endpoints.API.Categories
{
    [Route("api/Category")]
    public class CategoryCommandController : BaseController
    {

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CategoryCreateCommand command)
            => await Create<CategoryCreateCommand, long>(command);

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
            => await Delete(new CategoryDeleteCommand { CategoryId = id});

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CategoryUpdateCommand command)
            => await Edit<CategoryUpdateCommand, long>(command);
    }
}
