using Library_Management_API.Models.Enum;

namespace Library_Management_API.Models
{
    public class Reservation
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

