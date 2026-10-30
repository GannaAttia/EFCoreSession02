using EFCoreSession02.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreSession02
{
    public class ApplicationDBContext :DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=EventHubDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Badge>(builder =>
            {
                builder.HasKey(b => b.Id);

                builder.Property(b => b.BadgeNumber)
                       .IsRequired()
                       .HasMaxLength(50);

                builder.Property(b => b.Tier)
                       .HasConversion<string>(); 

                builder.HasOne(b => b.Attendee)
                       .WithOne(a => a.Badge)
                       .HasForeignKey<Badge>(b => b.AttendeeId)
                       .OnDelete(DeleteBehavior.Cascade);

                builder.HasIndex(b => b.BadgeNumber)
                       .IsUnique();
            });
        }
    }
}
