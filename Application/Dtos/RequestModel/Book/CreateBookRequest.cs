using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.RequestModel.Book
{
    public class CreateBookRequest
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        [MaxLength(40)]
        public string Publisher { get; set; }
        [Required]
        [MaxLength(40)]
        public string Author { get; set; }
        [Required]
        public string Image { get; set; }
        [Required] 
        public Guid CategoryId { get; set; }
        [Required]
        public DateTime PublicationDate { get; set; }
    }
}
