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
    [Migration("20240607131140_Initial")]
    partial class Initial
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
#pragma warning restore 612, 618
        }
    }
}
