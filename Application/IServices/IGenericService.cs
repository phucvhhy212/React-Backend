using Application.Dtos.ResponseModel;
using System.Linq.Expressions;

namespace Application.IServices
{
    public interface IGenericService<T> where T : class
    {
        Task<PaginatedResponse<IEnumerable<T>>> Get(int page = 1,int pageSize = 5,Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "");
        Task<BaseResponse<T?>> GetById(object id);
        Task<BaseResponse<T?>> Insert(T entity);
        Task<BaseResponse<T?>> Update(T entity);
        Task<BaseResponse<string>> Delete(T entity);
        Task<BaseResponse<string>> Delete(object id);
        Task<BaseResponse<string>> DeleteRange(List<object> ids);
    }
}
