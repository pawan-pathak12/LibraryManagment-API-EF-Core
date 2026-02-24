using Library_Management_API.Domain.Models;

namespace Library_Management_API.Shared.DTOs.FInes
{
    public class FineDto
    {
        public int FineId { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }

        public decimal Amount { get; set; }
        public string Reason { get; set; }
        public DateTime IssuedDate { get; set; }
        public bool PaidStatus { get; set; }
    }
}
