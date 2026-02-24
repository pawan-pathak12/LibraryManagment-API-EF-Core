namespace Library_Management_API.Domain.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }

        // Relationships
        public ICollection<Book> Books { get; set; }

    }
}
