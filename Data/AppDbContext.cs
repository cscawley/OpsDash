using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using TrivyDash.Models;

namespace TrivyDash.Data
{
    public class AppDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions){}
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