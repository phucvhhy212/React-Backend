using Application.Dtos.ResponseModel;
using Domain;

namespace Application.IServices
{
    public interface ICategoryService: IGenericService<Category>
    {
        Task<BaseResponse<string>> Delete(Guid id);
    }
}
