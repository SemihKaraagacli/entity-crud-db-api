using Microsoft.EntityFrameworkCore;

namespace LMS.Data.entities
{
    public class LMSDBContext : DbContext
    {
        public LMSDBContext(DbContextOptions<LMSDBContext> options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
