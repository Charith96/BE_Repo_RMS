using Microsoft.EntityFrameworkCore;
using conifs.rms.data.entities;

namespace conifs.rms.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePrivilege> RolePrivileges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Privilege entity
            modelBuilder.Entity<Privilege>()
                .HasKey(p => p.PrivilegeCode);

            // Configure Role entity
            modelBuilder.Entity<Role>()
                .HasKey(r => r.RoleCode);

            // Configure RolePrivilege entity
            modelBuilder.Entity<RolePrivilege>()
                .HasKey(rp => rp.RolePrivilegeCode);

            modelBuilder.Entity<RolePrivilege>()
                .HasOne(rp => rp.Role)
                .WithMany()
                .HasForeignKey(rp => rp.RoleCode);

            modelBuilder.Entity<RolePrivilege>()
                .HasOne(rp => rp.Privilege)
                .WithMany()
                .HasForeignKey(rp => rp.PrivilegeCode);
        }
    }
}
