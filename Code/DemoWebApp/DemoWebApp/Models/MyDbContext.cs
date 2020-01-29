using Microsoft.EntityFrameworkCore;

namespace DemoWebApp.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<Developer> developers { get; set; }
    }
}
