using Microsoft.EntityFrameworkCore;
using conifs.rms.data.entities;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Xml;

namespace conifs.rms.data
{
    public class CompanyDataContext : DbContext
    {
        public CompanyDataContext(DbContextOptions<CompanyDataContext> options) : base(options)
        {

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<Currency> Currencies { get; set; }



        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //    modelBuilder.Entity<CreateCompanyDto>()
        //      .HasOne(c => c.Country)
        //    .WithMany()
        //  .HasForeignKey(c => c.CountryID)
        // .OnDelete(DeleteBehavior.Cascade); // Or choose a different delete behavior
        //  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Other configurations...

            // Configure the CompanyID property conversion
            modelBuilder.Entity<Company>()
                .Property(e => e.CompanyID)
                .HasConversion(
                    v => v.ToString(),
                    v => Guid.Parse(v)
                );
        }

    }
}
