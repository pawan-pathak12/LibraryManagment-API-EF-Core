using System.ComponentModel.DataAnnotations;

namespace Library_Management_API.DTOs.Category
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
