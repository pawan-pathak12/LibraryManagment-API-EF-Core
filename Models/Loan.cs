using Library_Management_API.Models.Enum;

namespace Library_Management_API.Models
{
    public class Loan
    {
        public int LoanId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }

        public DateTime IssuedDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public LoanStatus Status { get; set; } // Issued, Returned, Overdue
    }
}
}
