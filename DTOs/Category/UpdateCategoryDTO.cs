using System.ComponentModel.DataAnnotations;

namespace Library_Management_API.DTOs.Category
{
    public class UpdateCategoryDTO
    {
        [Required]
        public string Name { get; set; }

     public int Id { get; set; }
       
    }
}
