namespace Domain
{
    public class BorrowingRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? RequesterId { get; set; }
        public virtual User? Requester { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime? DueDate { get; set; }
        public string Status { get; set; } = "Waiting";
        public Guid? ApproverId { get; set; }
        public virtual User? Approver { get; set; }
        public virtual ICollection<BorrowingRequestDetail> BorrowingRequestDetails { get; set; }

    }
}
