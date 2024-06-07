using Application.Dtos.ResponseModel;
using Domain;
using MySqlConnector;

namespace Application.IServices
{
    public interface IBookService:IGenericService<Book>
    {
        Task<BaseResponse<Book?>> GetById(Guid id);
        Task<PaginatedResponse<IEnumerable<Book>>> GetByCategoryId(Guid? id, string filter = "", int page = 1, int pageSize = 3);
        Task<BaseResponse<string>> Delete(Guid id);
    }
}
