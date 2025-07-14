using System.ComponentModel.DataAnnotations;

namespace Library_Management_API.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public DateOnly PublishedDate { get; set; }
        public int CategoryId { get; set; } 
        public Category Category { get; set; }

    }
}
