using System.Linq.Expressions;
using System.Reflection;
using Application.Dtos.ResponseModel;
using Application.IServices;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly ApplicationDbContext context;
        protected DbSet<T> dbSet;

        public GenericService(ApplicationDbContext context) 
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public async Task<PaginatedResponse<IEnumerable<T>>> Get(int page = 1, int pageSize = 5, Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            var total = query.Count();
            query = query.Skip((page - 1) * pageSize).Take(pageSize);
            foreach (var includeProperty in includeProperties.Split
                         (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return new PaginatedResponse<IEnumerable<T>>
                {
                    Body = orderBy(query).ToList(),
                    Total = total,
                    StatusCode = 200
                };
            }

            return new PaginatedResponse<IEnumerable<T>>
            {
                Body = await query.ToListAsync(),
                Total = total,
                StatusCode = 200
            };
        }

        public async Task<BaseResponse<T?>> GetById(object id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity != null)
            {
                return new BaseResponse<T?>
                {
                    Body = entity,
                    StatusCode = 200
                };
            }
            else
            {
                return new BaseResponse<T?>
                {
                    StatusCode = 404,
                    Message = "Entity not exist"
                };
            }
        
            
        }

        public async Task<BaseResponse<T?>> Insert(T entity)
        {
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
            return new BaseResponse<T?>
            {
                Message = "Create successfully",
                StatusCode = 200
            };
        }

        public async Task<BaseResponse<T?>> Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return new BaseResponse<T?>
            {
                Message = "Update successfully",
                StatusCode = 200
            };
        }

        public async Task<BaseResponse<string>> Delete(T entity)
        {
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
            return new BaseResponse<string>
            {
                Message = "Delete successfully",
                StatusCode = 200
            };
        }

        public async Task<BaseResponse<string>> Delete(object id)
        {
            var entityToDelete = await GetById(id);
            if (entityToDelete.StatusCode == 404)
            {
                return new BaseResponse<string>
                {
                    StatusCode = 404,
                    Message = "Entity not exist"
                };
            }

            return await Delete(entityToDelete.Body);
        }

        public async Task<BaseResponse<string>> DeleteRange(List<object> ids)
        {
            foreach (var id in ids)
            {
                var entity = await dbSet.FindAsync(id);
                if (entity == null)
                {
                    return new BaseResponse<string>
                    {
                        StatusCode = 404,
                        Message = "Entity not exist"
                    };
                }
            }
            foreach (var id in ids)
            {
                await Delete(id);
            }
            return new BaseResponse<string>
            {
                StatusCode = 200,
                Message = "Delete successfully"
            };
        }
    }
}
