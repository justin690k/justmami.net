using DBDesign.Model.CalenderSum.Event;
using DBDesign.Model.CalenderSum;
using DBDesign.Model.UserSum;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DBDesign
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<NotifactionType> NotifactionTypes { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<CalendarType> CalendarTypes { get; set; }
        public DbSet<CalendarUserSetting> CalendarUserSettings { get; set; }
        public DbSet<CalendarViewType> CalendarViewTypes { get; set; }
        public DbSet<SharedUserCalendar> SharedUserCalendars { get; set; }
        public DbSet<SharedUserVisibility> SharedUserVisibilities { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
        public DbSet<EventParticipantsStatus> EventParticipantsStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Define the SQLite connection string
            optionsBuilder.UseSqlite("Data Source=app.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ApplicationUser relationships
            modelBuilder.Entity<ApplicationUser>()
                .HasMany<UserSetting>()
                .WithOne(us => us.ApplicationUser)
                .HasForeignKey(us => us.UserId);

            // UserSetting relationships
            modelBuilder.Entity<UserSetting>()
                .HasKey(us => us.Id);
            modelBuilder.Entity<UserSetting>()
                .HasOne(us => us.ApplicationUser)
                .WithMany()
                .HasForeignKey(us => us.UserId);
            modelBuilder.Entity<UserSetting>()
                .HasOne(us => us.UserLanguage)
                .WithMany()
                .HasForeignKey(us => us.UserLanguageId);
            modelBuilder.Entity<UserSetting>()
                .HasOne(us => us.NotifactionType)
                .WithMany()
                .HasForeignKey(us => us.NotifactionTypeId);

            // Calendar relationships
            modelBuilder.Entity<Calendar>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Calendar>()
                .HasOne(c => c.ApplicationUser)
                .WithMany()
                .HasForeignKey(c => c.Owner)
                .OnDelete(DeleteBehavior.Restrict); // Restrict to avoid cycles
            modelBuilder.Entity<Calendar>()
                .HasOne(c => c.CalendarType)
                .WithMany()
                .HasForeignKey(c => c.CalendarTypeId);

            // CalendarUserSetting relationships
            modelBuilder.Entity<CalendarUserSetting>()
                .HasKey(cus => cus.Id);
            modelBuilder.Entity<CalendarUserSetting>()
                .HasOne(cus => cus.ApplicationUser)
                .WithMany()
                .HasForeignKey(cus => cus.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict to avoid cycles
            modelBuilder.Entity<CalendarUserSetting>()
                .HasOne(cus => cus.Calendar)
                .WithMany()
                .HasForeignKey(cus => cus.CalendarId);
            modelBuilder.Entity<CalendarUserSetting>()
                .HasOne(cus => cus.CalendarViewType)
                .WithMany()
                .HasForeignKey(cus => cus.CalendarViewTypeID);

            // SharedUserCalendar relationships
            modelBuilder.Entity<SharedUserCalendar>()
                .HasKey(suc => new { suc.SharedUserId, suc.CalendarId });
            modelBuilder.Entity<SharedUserCalendar>()
                .HasOne(suc => suc.ApplicationUser)
                .WithMany()
                .HasForeignKey(suc => suc.SharedUserId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict cascade delete to avoid issues
            modelBuilder.Entity<SharedUserCalendar>()
                .HasOne(suc => suc.Calendar)
                .WithMany()
                .HasForeignKey(suc => suc.CalendarId);
            modelBuilder.Entity<SharedUserCalendar>()
                .HasOne(suc => suc.SharedUserVisibility)
                .WithMany()
                .HasForeignKey(suc => suc.SharedUserVisibilityId);

            // Event relationships
            modelBuilder.Entity<Event>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Event>()
                .HasOne(e => e.ApplicationUser)
                .WithMany()
                .HasForeignKey(e => e.Owner)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete here as well

            // EventParticipant relationships
            modelBuilder.Entity<EventParticipant>()
                .HasKey(ep => new { ep.EventId, ep.SharedUserId });
            //modelBuilder.Entity<EventParticipant>()
            //    .HasOne(ep => ep.Event)
            //    .WithOne(e => e.EventParticipants)
            //    .HasForeignKey(ep => ep.EventId)
            //    .OnDelete(DeleteBehavior.Cascade); // Allow cascade delete for Event
            modelBuilder.Entity<EventParticipant>()
                .HasOne(ep => ep.ApplicationUser)
                .WithMany()
                .HasForeignKey(ep => ep.SharedUserId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict cascade delete to avoid cycles
            modelBuilder.Entity<EventParticipant>()
                .HasOne(ep => ep.ParticipantsStatus)
                .WithMany()
                .HasForeignKey(ep => ep.EventParticipantsStatusId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict cascade delete

            // EventParticipantsStatus relationships
            modelBuilder.Entity<EventParticipantsStatus>()
                .HasKey(eps => eps.Id);

            // CalendarType relationships
            modelBuilder.Entity<CalendarType>()
                .HasKey(ct => ct.Id);

            // CalendarViewType relationships
            modelBuilder.Entity<CalendarViewType>()
                .HasKey(cvt => cvt.Id);

            // NotifactionType relationships
            modelBuilder.Entity<NotifactionType>()
                .HasKey(nt => nt.Id);

            // SharedUserVisibility relationships
            modelBuilder.Entity<SharedUserVisibility>()
                .HasKey(suv => suv.Guid);
        }

    }


}
