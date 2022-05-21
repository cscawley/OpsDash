using Microsoft.EntityFrameworkCore;
using TrivyDash.Models;

namespace TrivyDash.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt){}
        public DbSet<Report> Report { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>()
                .Property(e => e._MetaData).HasColumnName("MetaData");
            modelBuilder.Entity<Report>()
                .Property(e => e._Result).HasColumnName("Result");
        }
    }
}