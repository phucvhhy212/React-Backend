namespace Domain
{
    public class BorrowingRequestDetail
    {
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }
        public Guid BorrowingRequestId { get; set; }
        public virtual BorrowingRequest BorrowingRequest { get; set; }
    }
}
