﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using conifs.rms.data;

#nullable disable

namespace conifs.rms.data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("conifs.rms.data.entities.Privilege", b =>
                {
                    b.Property<Guid>("PrivilegeCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PrivilegeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrivilegeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrivilegeCode");

                    b.ToTable("Privileges");
                });

            modelBuilder.Entity("conifs.rms.data.entities.Role", b =>
                {
                    b.Property<Guid>("RoleCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleID")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("RoleCode");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("conifs.rms.data.entities.RolePrivilege", b =>
                {
                    b.Property<Guid>("RolePrivilegeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PrivilegeCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleCode")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RolePrivilegeId");

                    b.ToTable("RolePrivileges");
                });
#pragma warning restore 612, 618
        }
    }
}
