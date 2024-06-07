namespace Application.Dtos.ResponseModel.BorrowingRequest
{
    public class BorrowingRequestDetailResponse
    {
        public string Status { get; set; }
        public string Requester { get; set; }
        public DateTime DateRequested { get; set; }
        public string Approver { get; set; }
        public ICollection<RequestDetails> Books { get; set; }
    }

    public class RequestDetails
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
