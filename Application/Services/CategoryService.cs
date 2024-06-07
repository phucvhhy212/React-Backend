using Application.Dtos.ResponseModel;
using Application.IServices;
using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace Application.Services
{
    public class CategoryService:GenericService<Category>,ICategoryService
    {
        public CategoryService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<BaseResponse<string>> Delete(Guid id)
        {
            var category = await context.Categories.Include(x=>x.Books).FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return new BaseResponse<string>
                {
                    StatusCode = 400,
                    Message = "Category not exist"
                };
            }

            if (category.Books.Count != 0)
            {
                return new BaseResponse<string>
                {
                    StatusCode = 400,
                    Message = "A book still in this category"
                };
            }

            return await base.Delete(category);
        }
    }
}
