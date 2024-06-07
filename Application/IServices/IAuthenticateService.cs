using Application.Dtos.RequestModel.Authenticate;
using Application.Dtos.ResponseModel;

namespace Application.IServices
{
    public interface IAuthenticateService
    {
        public Task<BaseResponse<string>> Login(LoginRequest request);
        public Task<BaseResponse<string>> Register(RegisterRequest request);
        
    }
}
