using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class User: IdentityUser<Guid>
    {
        public virtual ICollection<UserRequest>? UserRequests { get; set; }
        public virtual ICollection<BorrowingRequest>? BorrowingRequests { get; set; }

    }
}
