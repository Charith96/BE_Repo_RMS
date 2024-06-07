﻿using Microsoft.EntityFrameworkCore;
using conifs.rms.data.entities;

namespace conifs.rms.data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ReservationGroup> ReservationGroups { get; set; }
        public DbSet<ReservationItem> ReservationItems { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
