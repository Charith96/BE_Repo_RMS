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

       // public DbSet<CompanyCountry> CompanyCountries { get; set; }
      //  public DbSet<CompanyCurrency> companyCurrencies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the CompanyID property conversion
            modelBuilder.Entity<Company>()
                .Property(e => e.CompanyID)
                .HasConversion(
                    v => v.ToString(),
                    v => Guid.Parse(v)
                );

            modelBuilder.Entity<Country>()
           .Property(c => c.CountryID)
           .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>()
           .HasKey(c => new { c.CountryID });

            modelBuilder.Entity<Company>()
                .HasOne(c => c.Country)
                .WithMany()
                .HasForeignKey(c => c.CountryID);
               // .HasPrincipalKey(c => c.CountryName);

            modelBuilder.Entity<Currency>()
           .HasKey(c => new { c.CurrencyID });

            modelBuilder.Entity<Company>()
                .HasOne(c => c.Currency)
                .WithMany()
                .HasForeignKey(c => c.CurrencyID);
               // .HasPrincipalKey(c => c.CurrencyName);

            //    modelBuilder.Entity<CompanyCountry>()
            //        .HasKey(cc => new { cc.CompanyID, cc.CountryID });

            //    modelBuilder.Entity<CompanyCountry>()
            //        .HasOne(cc => cc.Company)
            //        .WithMany(c => c.CompanyCountries)
            //        .HasForeignKey(cc => cc.CompanyID);

            //    modelBuilder.Entity<CompanyCountry>()
            //        .HasOne(cc => cc.Country)
            //        .WithMany(c => c.CompanyCountries)
            //        .HasForeignKey(cc => cc.CountryID);

            //    modelBuilder.Entity<CompanyCurrency>()
            //.HasKey(cc => new { cc.CompanyID, cc.CurrencyID });

            //    modelBuilder.Entity<CompanyCurrency>()
            //        .HasOne(cc => cc.Company)
            //        .WithMany(c => c.CompanyCurrencies)
            //        .HasForeignKey(cc => cc.CompanyID);

            //    modelBuilder.Entity<CompanyCurrency>()
            //        .HasOne(cc => cc.Currency)
            //        .WithMany(c => c.CompanyCurrencies)
            //        .HasForeignKey(cc => cc.CurrencyID);
        }
    }
}
