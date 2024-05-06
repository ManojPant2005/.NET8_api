using Microsoft.EntityFrameworkCore;
using StudentAPI.Data.Models;

namespace StudentAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }            
    }
}
