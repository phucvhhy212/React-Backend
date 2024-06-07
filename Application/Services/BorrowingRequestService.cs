using Application.Dtos.RequestModel.BorrowingRequest;
using Application.Dtos.ResponseModel;
using Application.Dtos.ResponseModel.BorrowingRequest;
using Application.IServices;
using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class BorrowingRequestService:GenericService<BorrowingRequest>,IBorrowingRequestService
    {
        public BorrowingRequestService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<BaseResponse<BorrowingRequest?>> Insert(CreateBorrowingRequestRequest request)
        {
            if (context.BorrowingRequests.Count(x => x.RequesterId == request.RequesterId && x.DateRequested.Month == DateTime.Now.Month) == 3)
            {
                return new BaseResponse<BorrowingRequest?>
                {
                    StatusCode = 400,
                    Message = "Maximum request per month (3)"
                };
            }

            var borrowingRequest = new BorrowingRequest
            {
                RequesterId = request.RequesterId,
                DateRequested = request.DateRequested,
            };
            var borrowingRequestDetails = request.Books.Select(id => new BorrowingRequestDetail
            {
                BookId = id,
                BorrowingRequest = borrowingRequest
            }).ToList();
            
            await context.BorrowingRequests.AddAsync(borrowingRequest);
            await context.BorrowingRequestDetails.AddRangeAsync(borrowingRequestDetails);
            var userRequests = context.UserRequests.Where(x => x.RequesterId == request.RequesterId);
            context.UserRequests.RemoveRange(userRequests);
            await context.SaveChangesAsync();
            return new BaseResponse<BorrowingRequest?>
            {
                StatusCode = 200,
                Message = "Create request successfully"
            };
        }

        public async Task<BaseResponse<IEnumerable<BorrowingRequest>>?> GetUserBorrowingHistory(Guid id)
        {
            return new BaseResponse<IEnumerable<BorrowingRequest>>
            {
                StatusCode = 200,
                Body = await context.BorrowingRequests.Include(x => x.BorrowingRequestDetails).ThenInclude(x => x.Book)
                    .Where(x => x.RequesterId == id).ToListAsync()
            };
        }

        public async Task<BaseResponse<BorrowingRequest?>> GetBorrowingRequestDetail(Guid id)
        {
            var findResponse = await context.BorrowingRequests.Include(x=>x.Requester).Include(x=>x.Approver).Include(x=>x.BorrowingRequestDetails).ThenInclude(x=>x.Book).FirstOrDefaultAsync(x => x.Id == id);
            if (findResponse != null)
            {
                return new BaseResponse<BorrowingRequest?>
                {
                    StatusCode = 200,
                    Body = findResponse
                };
            }
            return new BaseResponse<BorrowingRequest?>
            {
                StatusCode = 400,
                Message = "Request not exist"
            };
        }

        public async Task<BaseResponse<BorrowingRequest?>> ChangeStatus(Guid id, Guid approverId, string status)
        {
            var response = await GetById(id);
            if (response.StatusCode == 200)
            {
                var request = response.Body;
                request.Status = status;
                if (status == "Approved")
                {
                    request.ApproverId = approverId;
                }
                else
                {
                    request.ApproverId = null;
                }
                return await Update(request);
            }

            return new BaseResponse<BorrowingRequest?>
            {
                StatusCode = response.StatusCode,
                Message = response.Message
            };
        }
    }
}
