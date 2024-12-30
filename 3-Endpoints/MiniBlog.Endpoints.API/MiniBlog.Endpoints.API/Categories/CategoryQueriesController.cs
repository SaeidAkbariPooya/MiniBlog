using Microsoft.AspNetCore.Mvc;
using MiniBlog.Core.Contracts.Categories.Queries.GetAllCategory;
using MiniBlog.Core.Contracts.Categories.Queries.GetCategoryById;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.EndPoints.Web.Controllers;

namespace MiniBlog.Endpoints.API.Categories
{
    [Route("api/Category")]
    public class CategoryQueriesController : BaseController
    {

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(GetAllCategoryQuery query)
               => await Query<GetAllCategoryQuery, PagedData<CategoryDto>>(query);

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(long id)
               => await Query<GetCategoryByBusinessIdQuery, CategoryDto>(new GetCategoryByBusinessIdQuery { CategoryId = id });
    }
}
