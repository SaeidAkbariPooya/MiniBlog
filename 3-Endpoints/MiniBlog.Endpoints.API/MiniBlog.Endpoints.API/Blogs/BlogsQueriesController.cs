using Microsoft.AspNetCore.Mvc;
using MiniBlog.Core.Contracts.Blogs.Queries.GetAllBlog;
using MiniBlog.Core.Contracts.Blogs.Queries.GetBlogById;
using MiniBlog.Core.Contracts.Categories.Queries.GetAllCategory;
using MiniBlog.Core.Contracts.Categories.Queries.GetCategoryById;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.EndPoints.Web.Controllers;

namespace MiniBlog.Endpoints.API.Blogs
{
    [Route("api/Blog")]
    public class BlogsQueriesController : BaseController
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(GetAllBlogQuery query)
                => await Query<GetAllBlogQuery, PagedData<BlogDto>>(query);

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(long id)
               => await Query<GetBlogByIdQuery, BlogDto>(new GetBlogByIdQuery { Id = id });
    }
}
