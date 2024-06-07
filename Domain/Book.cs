namespace Domain
{
    public class Book
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public DateTime PublicationDate { get; set; }
        public virtual ICollection<UserRequest>? UserRequests { get; set; }
        public virtual ICollection<BorrowingRequestDetail>? BorrowingRequestDetails { get; set; } 

    }
}
