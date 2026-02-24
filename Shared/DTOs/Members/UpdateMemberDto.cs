namespace Library_Management_API.Shared.DTOs.Members
{
    public class UpdateMemberDto
    {
        public int MemberId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime MembershipDate { get; set; }
        public string MembershipType { get; set; }
        public bool IsActive { get; set; }

        // Relationships
        //      public ICollection<Loan> Loans { get; set; }
        //    public ICollection<Reservation> Reservations { get; set; }
    }
}
