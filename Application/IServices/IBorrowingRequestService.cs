using Application.Dtos.RequestModel.BorrowingRequest;
using Application.Dtos.ResponseModel;
using Domain;

namespace Application.IServices
{
    public interface IBorrowingRequestService:IGenericService<BorrowingRequest>
    {
        Task<BaseResponse<BorrowingRequest?>> Insert(CreateBorrowingRequestRequest request);
        Task<BaseResponse<IEnumerable<BorrowingRequest>>?> GetUserBorrowingHistory(Guid id);
        Task<BaseResponse<BorrowingRequest?>> ChangeStatus(Guid id, Guid approverId, string status);
        Task<BaseResponse<BorrowingRequest?>> GetBorrowingRequestDetail(Guid id);

    }
}
