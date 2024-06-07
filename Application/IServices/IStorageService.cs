using Application.Dtos.ResponseModel;
using Microsoft.AspNetCore.Http;

namespace Application.IServices
{
    public interface IStorageService
    {
        BaseResponse<string> GetStorageUrl(IFormFile file);
        Task<BaseResponse<string>> GetObjectFinalVersionId(string objectKey);

    }
}
