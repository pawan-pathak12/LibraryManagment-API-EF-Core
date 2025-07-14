using System.ComponentModel.DataAnnotations;

namespace Library_Management_API.Models
{
    public class Category
    {
        
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
       
        // Navigation property for related books
        public ICollection<Book> Books { get; set; } 
    }
}
