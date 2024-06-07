using Application.Dtos.ResponseModel;
using Domain;

namespace Application.IServices
{
    public interface IUserRequestService:IGenericService<UserRequest>
    {
        Task<BaseResponse<IEnumerable<UserRequest>>> GetUserRequest(Guid id);
        new Task<BaseResponse<UserRequest?>> Insert(UserRequest request);
    }
}
