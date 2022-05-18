using Microsoft.EntityFrameworkCore;
using TrivyDash.Models;

namespace TrivyDash.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        public DbSet<Report> Report { get; set; }
    }
}