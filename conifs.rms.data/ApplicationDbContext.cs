﻿//using conifs.rms.data.entities;
//using Microsoft.EntityFrameworkCore;

//namespace conifs.rms.data
//{
//public class ApplicationDbContext : DbContext
//  {
//    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//      : base(options)
//{
//}

//public DbSet<Role> Roles { get; set; }
// public DbSet<Privilege> Privileges { get; set; }
// public DbSet<RolePrivilege> RolePrivileges { get; set; }


//}
//}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using conifs.rms.data.entities;
using System.Data;
using conifs.rms.dto;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics.Metrics;



namespace conifs.rms.data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<ReservationGroup> ReservationGroups { get; set; }
        public DbSet<ReservationItem> ReservationItems { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }

        public DbSet<UserTable> User { get; set; }
        public DbSet<UserCompany> UserCompany { get; set; }
        public DbSet<UserRoles> UserRole { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Role> Roles { get; set; }
        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<RoleWithPrivileges> RolePrivileges { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { // Other configurations...
          // Configure entity mappings and relationships

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RoleWithPrivileges>()
                .HasKey(rp => rp.RolePrivilegeCode);

            modelBuilder.Entity<RoleWithPrivileges>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePrivileges)
                .HasForeignKey(rp => rp.RoleCode);

            modelBuilder.Entity<RoleWithPrivileges>()
                .HasOne(rp => rp.Privilege)
                .WithMany(p => p.RolePrivileges)
                .HasForeignKey(rp => rp.PrivilegeCode);




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

            modelBuilder.Entity<ReservationItem>(entity =>
            {
                entity.HasOne(e => e.ReservationGroup)
                      .WithMany()
                      .HasForeignKey(ri => ri.GroupId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Ignore navigation property
                entity.Ignore(ri => ri.ReservationGroup);
            });

            modelBuilder.Entity<TimeSlot>(entity =>
            {
                entity.HasOne(e => e.ReservationItem)
                      .WithMany()
                      .HasForeignKey(ts => ts.ItemId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Ignore navigation property
                entity.Ignore(ts => ts.ReservationItem);
            });


            base.OnModelCreating(modelBuilder);
        }



    }
}


