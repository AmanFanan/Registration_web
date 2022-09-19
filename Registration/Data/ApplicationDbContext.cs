using Microsoft.EntityFrameworkCore;
using Registration.Models;

namespace Registration.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee_Registration> Employee_Registrations { get; set; }
        public DbSet<States> States { get; set; }
    }
}
