using Microsoft.EntityFrameworkCore;
using conifs.rms.data.entities;
using conifs.rms.dto;



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
        public DbSet<Company> Companies { get; set; }
        public DbSet<Roles> Roles { get; set; }

      


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity mappings and relationships
            modelBuilder.Entity<Roles>()
     .HasKey(r => r.RoleId);
            modelBuilder.Entity<ReservationItem>()
                .HasOne(ri => ri.ReservationGroup)
                .WithMany()
                .HasForeignKey(ri => ri.groupId);

            modelBuilder.Entity<UserCompany>()
                .HasKey(uc => new { uc.Userid, uc.CompanyId });

            modelBuilder.Entity<UserCompany>()
                .HasOne(uc => uc.Company)
                .WithMany(c => c.UserCompanies)
                .HasForeignKey(uc => uc.CompanyId);

            modelBuilder.Entity<UserRoles>()
                .HasKey(ur => new { ur.Userid, ur.RoleId });

            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<GetUserDto>().HasNoKey();
            modelBuilder.Entity<CreateUserDto>().HasNoKey();
            modelBuilder.Entity<CreateUserDto>().HasNoKey();
            modelBuilder.Entity<CreateUserCompanyDto>().HasNoKey();
            modelBuilder.Entity<CreateUserRoleDto>().HasNoKey();
            modelBuilder.Entity<PutUserDto>()
             .HasKey(r => r.Userid);
            base.OnModelCreating(modelBuilder);

           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-6VTO6PFL;Initial Catalog=New;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False", b => b.MigrationsAssembly("conifs.rms.base.api"));

        }
    }
}
