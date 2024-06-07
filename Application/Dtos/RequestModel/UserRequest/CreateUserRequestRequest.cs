using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.RequestModel.UserRequest
{
    public class CreateUserRequestRequest
    {
        [Required]
        public Guid BookId { get; set; }
    }
}