using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.RequestModel.Authenticate
{
    public class RegisterRequest
    {
        [EmailAddress]
        [MinLength(8)]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [MinLength(4)]
        public string UserName { get; set; }
    }
}
