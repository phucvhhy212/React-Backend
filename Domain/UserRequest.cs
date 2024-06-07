namespace Domain
{
    public class UserRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid RequesterId { get; set; }
        public virtual User Requester { get; set; }
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }

    }
}
