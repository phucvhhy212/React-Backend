namespace Application.Dtos.ResponseModel;

public class BaseResponse<T>
{
    public T? Body { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }
}