namespace Application.Dtos.ResponseModel
{
    public class PaginatedResponse<T>:BaseResponse<T>
    {
        public int? Total { get; set; }
    }
}
