using Application.Dtos.ResponseModel;
using Application.IServices;
using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class UserRequestService:GenericService<UserRequest>,IUserRequestService
    {
        public UserRequestService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<BaseResponse<IEnumerable<UserRequest>>> GetUserRequest(Guid id)
        {
            return new BaseResponse<IEnumerable<UserRequest>>
            {
                StatusCode = 200,
                Body = await context.UserRequests.Include(x=>x.Requester).Include(x => x.Book).ThenInclude(x=>x.Category).Where(x => x.RequesterId == id).ToListAsync()
            };

        }
        public async Task<BaseResponse<UserRequest?>> Insert(UserRequest request)
        {
            if (!await context.Books.AnyAsync(x => x.Id == request.BookId))
            {
                return new BaseResponse<UserRequest?>
                {
                    StatusCode = 400,
                    Message = "Book not exist"
                };
            }
            var requests = context.UserRequests.Where(x => x.RequesterId == request.RequesterId);
            if (requests.Count() == 5)
            {
                return new BaseResponse<UserRequest?>
                {
                    StatusCode = 400,
                    Message = "Only 5 books per request"
                };
            }

            if (requests.Any(x => x.BookId == request.BookId))
            {
                return new BaseResponse<UserRequest?>
                {
                    StatusCode = 400,
                    Message = "Book already in the request"
                };
            }
            return await base.Insert(request);

        }
    }
}
