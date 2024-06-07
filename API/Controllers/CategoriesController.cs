using Application.Dtos.RequestModel.Category;
using Application.IServices;
using Application.Services;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Exception = System.Exception;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int currentPage, int pageSize, string? name, string? sortBy, string? sortOrder)
        {
            try
            {
                Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy;
                switch (sortBy?.ToLower())
                {
                    case "name":
                        orderBy = x => sortOrder != "desc" ? x.OrderBy(b => b.Name) : x.OrderByDescending(b => b.Name);
                        break;
                    case "id":
                        orderBy = x => sortOrder != "desc" ? x.OrderBy(b => b.Id) : x.OrderByDescending(b => b.Id);
                        break;
                    default:
                        orderBy = null;
                        break;
                }
                return Ok(await _categoryService.Get(
                    page: currentPage == 0 ? 1 : currentPage,
                    pageSize: pageSize == 0 ? 5 : pageSize,
                    filter: String.IsNullOrEmpty(name) ? null : x => x.Name.Contains(name),
                    orderBy: String.IsNullOrEmpty(sortBy)
                        ? null
                        : orderBy
                ));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _categoryService.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(CreateCategoryRequest request)
        {
            try
            {
                var category = _mapper.Map<Category>(request);
                return Ok(await _categoryService.Insert(category));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(Guid id,CreateCategoryRequest request)
        {
            try
            {
                var findCategoryResponse = await _categoryService.GetById(id);
                if (findCategoryResponse.StatusCode == 200)
                {
                    var findCategory = findCategoryResponse.Body;
                    findCategory.Name = request.Name;
                    findCategory.Image = request.Image;
                    return Ok(await _categoryService.Update(findCategory));
                }

                return Ok(findCategoryResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                return Ok(await _categoryService.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
