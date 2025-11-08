using Library_Management_API.Models.Enum;

namespace Library_Management_API.DTOs.Reservations
{
    public class CreateReservationDto
    {
        public int BookId { get; set; }

        public int MemberId { get; set; }

        public DateTime ReservationDate { get; set; }
        public ReservationStatus Status { get; set; } // Pending, Fulfilled, Cancelled
    }
}
