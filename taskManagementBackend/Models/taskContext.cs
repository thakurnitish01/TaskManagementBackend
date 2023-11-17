using DotNetAngularApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace taskManagementBackend.Models
{
    public class taskContext : DbContext
    {
        public taskContext(DbContextOptions<taskContext> options) :  base(options) { }
        public DbSet<taskModel> taskModel { get; set;}
        public DbSet<User> user { get; set; }
    }
}

