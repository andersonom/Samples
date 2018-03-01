using Microsoft.EntityFrameworkCore;

namespace StudentsManager.Data
{
    public class StudentsManagerContext : DbContext
    {
        public StudentsManagerContext (DbContextOptions<StudentsManagerContext> options)
            : base(options)
        {
        }

        public DbSet<StudentsManager.Domain.Models.Student> Student { get; set; }

        public DbSet<StudentsManager.Domain.Models.Course> Course { get; set; }

        public DbSet<StudentsManager.Domain.Models.Address> Address { get; set; }
    }
}
