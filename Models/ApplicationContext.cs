#nullable disable
using Microsoft.EntityFrameworkCore;

namespace ThanksCardAPI.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ThanksCard> ThanksCards { get; set; }
        public DbSet<MS_CLASSIFICATION> Classifications { get; set; }
        public DbSet<ThanksCard2> ThanksCard2s { get; set; }
    }
}
