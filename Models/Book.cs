using System.ComponentModel.DataAnnotations;

namespace Library_Management_API.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateOnly PublishedDate { get; set; }
        public int CategoryId { get; set; } 
        public Category Category { get; set; }

    }
}
