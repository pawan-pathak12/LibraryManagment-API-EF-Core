namespace Library_Management_API.DTOs.Book
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateOnly PublishedDate { get; set; }

        public string CategoryName { get; set; }
    }
}
