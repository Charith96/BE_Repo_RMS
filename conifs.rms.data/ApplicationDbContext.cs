using Microsoft.EntityFrameworkCore;
using conifs.rms.data.entities;

namespace conifs.rms.data
{
    public class ApplicationDbContext : DbContext
{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ReservationGroup> ReservationGroups { get; set; }
        public DbSet<ReservationItem> ReservationItems { get; set; }
        public DbSet<UserTable> User { get; set; }
        public DbSet<UserCompany> UserCompany { get; set; }
        public DbSet<UserRoles> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity mappings and relationships
            modelBuilder.Entity<ReservationItem>()
                .HasOne(ri => ri.ReservationGroup)
                .WithMany()
                .HasForeignKey(ri => ri.groupId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-6VTO6PFL;Initial Catalog=ProjectBE;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
