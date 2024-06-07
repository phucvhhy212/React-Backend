using Application.Dtos.RequestModel.Book;
using Application.Dtos.ResponseModel;
using Application.Dtos.ResponseModel.Book;
using Application.IServices;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int currentPage, int pageSize, string? name, string? sortBy, string? sortOrder)
        {
            try
            {
                Func<IQueryable<Book>, IOrderedQueryable<Book>>? orderBy;
                switch (sortBy?.ToLower())
                {
                    case "name":
                        orderBy = x => sortOrder != "desc" ? x.OrderBy(b => b.Name) : x.OrderByDescending(b => b.Name);
                        break;
                    case "id":
                        orderBy = x => sortOrder != "desc" ? x.OrderBy(b => b.Id) : x.OrderByDescending(b => b.Id);
                        break;
                    case "description":
                        orderBy = x => sortOrder != "desc" ? x.OrderBy(b => b.Description) : x.OrderByDescending(b => b.Description);
                        break;
                    default:
                        orderBy = null;
                        break;
                }
                return Ok(await _bookService.Get(
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
                var response = await _bookService.GetById(id);
                if (response.StatusCode == 200)
                {
                    return Ok(new BaseResponse<AdminBookDetailResponse>
                    {
                        StatusCode = 200,
                        Body = _mapper.Map<AdminBookDetailResponse>(response.Body)
                    }
                    );
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetByCategoryId")]
        public async Task<IActionResult> GetByCategoryId(Guid? categoryId, string filter = "", int currentPage = 1, int pageSize = 3)
        {
            try
            {
                return Ok(await _bookService.GetByCategoryId(categoryId, filter, currentPage, pageSize));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBookRequest request)
        {
            try
            {
                var book = _mapper.Map<Book>(request);
                return Ok(await _bookService.Insert(book));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id,CreateBookRequest request)
        {
            try
            {
                var findBookResponse = await _bookService.GetById(id);
                if (findBookResponse.StatusCode == 200)
                {
                    var findBook = findBookResponse.Body;
                    findBook.Name = request.Name;
                    findBook.Author = request.Author;
                    findBook.CategoryId = request.CategoryId;
                    findBook.Description = request.Description;
                    findBook.Image = request.Image;
                    findBook.PublicationDate = request.PublicationDate;
                    findBook.Publisher = request.Publisher;
                    return Ok(await _bookService.Update(findBook));
                }

                return Ok(findBookResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                return Ok(await _bookService.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
