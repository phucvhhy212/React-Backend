namespace Application.Dtos.ResponseModel.UserRequest
{
    public class GetUserRequestResponse
    {
        public Guid Id { get; set; }
        public string RequesterName { get; set; }
        public Guid BookId { get; set; }
        public string BookImage { get; set; }
        public string BookName { get; set; }
        public string CategoryName { get; set; }
        public string Author { get; set; }
    }
}
