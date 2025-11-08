using Library_Management_API.Models;

namespace Library_Management_API.DTOs.Publishers
{
    public class PublisherDto
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }

        // Relationships
        public ICollection<Book> Books { get; set; }

    }
}
