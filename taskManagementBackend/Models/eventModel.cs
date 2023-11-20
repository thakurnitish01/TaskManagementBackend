namespace taskManagementBackend.Models
{
    public class eventModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string EventTitle { get; set; }
        public string Description { get; set; }
        public string location { get; set; }
        public bool IsActive { get; set; }
        public DateTime Time { get; set; }
        public int TotalTicketSeats { get; } = 40;
        public ICollection<TicketBooking> Tickets { get; set; } = new List<TicketBooking>();
    }
}
