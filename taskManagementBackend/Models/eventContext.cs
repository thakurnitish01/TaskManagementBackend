using DotNetAngularApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace taskManagementBackend.Models
{
    public class eventContext : DbContext
    {
        public eventContext(DbContextOptions<eventContext> options) :  base(options) { }
        public DbSet<eventModel> eventModel { get; set;}
        public DbSet<User> user { get; set; }
        public DbSet<TicketBooking> ticketBooking { get; set; }
    }
}

