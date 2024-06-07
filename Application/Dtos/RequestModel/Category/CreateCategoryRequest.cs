using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.RequestModel.Category
{
    public class CreateCategoryRequest
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
