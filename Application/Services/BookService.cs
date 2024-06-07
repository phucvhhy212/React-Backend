using Application.Dtos.ResponseModel;
using Application.IServices;
using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class BookService:GenericService<Book>,IBookService
    {
        public BookService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<BaseResponse<Book?>> GetById(Guid id)
        {
            var book = await context.Books.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
            {
                return new BaseResponse<Book?>
                {
                    StatusCode = 404,
                    Message = "Book not exist"
                };
            }

            return new BaseResponse<Book?>
            {
                StatusCode = 200,
                Body = book
            };
        }

        public async Task<PaginatedResponse<IEnumerable<Book>>> GetByCategoryId(Guid? id, string filter = "", int page = 1, int pageSize = 3)
        {
            IQueryable<Book> query = context.Books;

            if (id.HasValue)
            {
                if(!await context.Categories.AnyAsync(x => x.Id == id)){
                    return new PaginatedResponse<IEnumerable<Book>>
                    {
                        StatusCode = 400,
                        Message = "Category not exist"
                    };
                }
                query = query.Where(x => x.CategoryId == id);
            }

            if (!String.IsNullOrEmpty(filter))
            {
                query = query.Where(x => x.Name.Contains(filter) || x.Description.Contains(filter) || x.Publisher.Contains(filter) || x.Author.Contains(filter));
            }
            var total = query.Count();
            query = query.Skip((page - 1) * pageSize).Take(pageSize);
            return new PaginatedResponse<IEnumerable<Book>>
            {
                Body = await query.ToListAsync(),
                Total = total,
                StatusCode = 200
            };
        }


        public async Task<BaseResponse<string>> Delete(Guid id)
        {
            var findBook = await dbSet.Include(x => x.UserRequests).Include(x => x.BorrowingRequestDetails)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (findBook == null)
            {
                return new BaseResponse<string>
                {
                    StatusCode = 404,
                    Message = "Book not exist"
                };
            }

            if (findBook.UserRequests.Any() || findBook.BorrowingRequestDetails.Any())
            {
                return new BaseResponse<string>
                {
                    StatusCode = 400,
                    Message = "Book is in a loan request"
                };
            }

            return await Delete(findBook);

        }
    }
}
