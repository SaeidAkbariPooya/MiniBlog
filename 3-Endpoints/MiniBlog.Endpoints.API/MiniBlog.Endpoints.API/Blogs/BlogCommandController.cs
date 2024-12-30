using Microsoft.AspNetCore.Mvc;
using MiniBlog.Core.Contracts.Blogs.Commands.CreateBlog;
using MiniBlog.Core.Contracts.Blogs.Commands.DeleteBlog;
using MiniBlog.Core.Contracts.Blogs.Commands.UpdateBlog;
using Zamin.EndPoints.Web.Controllers;

namespace MiniBlog.Endpoints.API.Blogs
{
    [Route("api/Blog")]
    public class BlogCommandController : BaseController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] BlogCreateCommand command)
               => await Create<BlogCreateCommand, long>(command);

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
               => await Delete(new BlogDeleteCommand { BlogId = id });

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] BlogUpdateCommand command)
               => await Edit<BlogUpdateCommand, long>(command);
    }
}
