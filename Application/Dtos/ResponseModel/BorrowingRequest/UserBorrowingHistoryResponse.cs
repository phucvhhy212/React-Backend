namespace Application.Dtos.ResponseModel.BorrowingRequest
{
    public class UserBorrowingHistoryResponse
    {
        public Guid Id { get; set; }
        public DateTime DateRequested { get; set; }
        public string Status { get; set; }
        public ICollection<UserBorrowingHistoryDetail> Details { get; set; }
    }

    public class UserBorrowingHistoryDetail
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
