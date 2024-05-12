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
    [Migration("20240503052146_Initial")]
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

            modelBuilder.Entity("conifs.rms.data.entities.ReservationGroup", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("groupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ReservationGroups");
                });

            modelBuilder.Entity("conifs.rms.data.entities.ReservationItem", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("capacity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("durationPerSlot")
                        .HasColumnType("int");

                    b.Property<Guid>("groupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("itemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("noOfReservations")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("noOfSlots")
                        .HasColumnType("int");

                    b.Property<string>("slotDurationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("timeSlotType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("groupId");

                    b.ToTable("ReservationItems");
                });

            modelBuilder.Entity("conifs.rms.data.entities.ReservationItem", b =>
                {
                    b.HasOne("conifs.rms.data.entities.ReservationGroup", "ReservationGroup")
                        .WithMany()
                        .HasForeignKey("groupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReservationGroup");
                });
#pragma warning restore 612, 618
        }
    }
}
