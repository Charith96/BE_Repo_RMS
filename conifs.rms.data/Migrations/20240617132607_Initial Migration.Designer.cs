﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using conifs.rms.data;

#nullable disable

namespace conifs.rms.data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240617132607_Initial Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleCode");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("conifs.rms.data.entities.RolePrivilege", b =>
                {
                    b.Property<Guid>("RolePrivilegeCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PrivilegeCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleCode")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RolePrivilegeCode");

                    b.HasIndex("PrivilegeCode");

                    b.HasIndex("RoleCode");

                    b.ToTable("RolePrivileges");
                });

            modelBuilder.Entity("conifs.rms.data.entities.RolePrivilege", b =>
                {
                    b.HasOne("conifs.rms.data.entities.Privilege", "Privilege")
                        .WithMany()
                        .HasForeignKey("PrivilegeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("conifs.rms.data.entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Privilege");

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
