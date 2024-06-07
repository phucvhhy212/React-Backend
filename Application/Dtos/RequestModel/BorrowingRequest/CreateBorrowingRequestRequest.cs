using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.RequestModel.BorrowingRequest
{
    public class CreateBorrowingRequestRequest
    {
        [Required]
        public Guid RequesterId { get; set; }
        [Required]
        public DateTime DateRequested { get; set; }
        [Required]
        public ICollection<Guid> Books { get; set; }

    }
}