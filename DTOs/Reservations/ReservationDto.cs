using Library_Management_API.Models;
using Library_Management_API.Models.Enum;

namespace Library_Management_API.DTOs.Reservations
{
    public class ReservationDto
    {
        public int ReservationId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }

        public DateTime ReservationDate { get; set; }
        public ReservationStatus Status { get; set; } // Pending, Fulfilled, Cancelled
    }
}
