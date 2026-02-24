using System.ComponentModel.DataAnnotations;

namespace Library_Management_API.Shared.DTOs.Books
{
    public class CreateBookDto
    {
        [Required][MaxLength(100)] public string Title { get; set; }

        [Required] public string Author { get; set; }

        public DateOnly PublishedDate { get; set; }

        [Required] public int CategoryId { get; set; }
    }
}
