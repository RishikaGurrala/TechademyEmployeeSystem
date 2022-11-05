using Microsoft.EntityFrameworkCore;
using Techademy_Employee_System.Models;

namespace Techademy_Employee_System.Data
{
    public class TechademyDbContext:DbContext
    {
        public TechademyDbContext()
        {
        }

        public TechademyDbContext(DbContextOptions<TechademyDbContext> x) : base(x)
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<Designation> designation { get; set; }
        public DbSet<Employee> employee { get; set; }
        public DbSet<WorkingHours> workinghours { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MC1JULY19\\RISHIKA;Database=Techademy;Trusted_Connection=True;");
            }
        }
    }
}
