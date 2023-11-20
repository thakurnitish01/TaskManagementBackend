using System.ComponentModel.DataAnnotations.Schema;

namespace taskManagementBackend.Models
{
    public class TicketBooking
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string PersonName { get; set; }
        public string PersonAge { get; set;}
        public string PersonGender { get; set;}
        public string PersonPhone { get; set;}

    }
}
