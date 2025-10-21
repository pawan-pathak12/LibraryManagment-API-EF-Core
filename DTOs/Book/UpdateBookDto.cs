using System.ComponentModel.DataAnnotations;

namespace Library_Management_API.DTOs.Book;

public class UpdateBookDto
{
    public int Id { get; set; }

    [Required] [MaxLength(100)] public string Title { get; set; }

    [Required] public string Author { get; set; }

    public DateOnly PublishedDate { get; set; }

    [Required] public int CategoryId { get; set; }
}