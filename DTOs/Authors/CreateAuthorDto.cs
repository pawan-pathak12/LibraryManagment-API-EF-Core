namespace Library_Management_API.DTOs.Authors
{
    public class CreateAuthorDto
    {
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }

        // Relationships
        //   public ICollection<Book> Books { get; set; }
    }
}
