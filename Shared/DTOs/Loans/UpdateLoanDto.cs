using Library_Management_API.Domain.Models.Enum;

namespace Library_Management_API.Shared.DTOs.Loans
{
    public class UpdateLoanDto
    {
        public int LoanId { get; set; }
        public int BookId { get; set; }

        public int MemberId { get; set; }

        public DateTime IssuedDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public LoanStatus Status { get; set; } // Issued, Returned, Overdue
    }
}
