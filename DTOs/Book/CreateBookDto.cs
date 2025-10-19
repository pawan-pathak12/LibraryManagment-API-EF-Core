using System.ComponentModel.DataAnnotations;

namespace Library_Management_API.DTOs.Book
{
    public class CreateBookDto
    {

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        public DateOnly PublishedDate { get; set; }

        [Required(ErrorMessage = "Category ID is required")]
        public int CategoryId { get; set; }
    }
}
