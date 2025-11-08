using Library_Management_API.Models;

namespace Library_Management_API.DTOs.Authors
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }

        // Relationships
        public ICollection<Book> Books { get; set; }
    }
}
