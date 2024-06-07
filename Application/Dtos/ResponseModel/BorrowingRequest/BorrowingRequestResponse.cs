namespace Application.Dtos.ResponseModel.BorrowingRequest
{
    public class BorrowingRequestResponse
    {
        public Guid Id { get; set; }
        public string Requester { get; set; }
        public DateTime DateRequested { get; set; }
        public string Status { get; set; }

    }
}
