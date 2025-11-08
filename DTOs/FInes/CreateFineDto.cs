using Library_Management_API.Models;

namespace Library_Management_API.DTOs.FInes
{
    public class CreateFineDto
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }

        public decimal Amount { get; set; }
        public string Reason { get; set; }
        public DateTime IssuedDate { get; set; }
        public bool PaidStatus { get; set; }
    }
}
