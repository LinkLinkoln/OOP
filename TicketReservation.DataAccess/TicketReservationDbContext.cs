using Microsoft.EntityFrameworkCore;
using TicketReservation.Core.Models;
using TicketReservation.DataAccess.Entities;

namespace TicketReservation.DataAccess
{
    public class TicketReservationDbContext : DbContext
    {
        public TicketReservationDbContext(DbContextOptions<TicketReservationDbContext> options) : base(options) 
        {

        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Seat> Seats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Event)
                .WithMany(e => e.Tickets)
                .HasForeignKey(t => t.EventId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Seat)
                .WithMany(s => s.Tickets)
                .HasForeignKey(t => t.SeatId);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Venue)
                .WithMany(v => v.Events)
                .HasForeignKey(e => e.VenueId);

            modelBuilder.Entity<Seat>()
                .HasOne(s => s.Venue)
                .WithMany(v => v.Seats)
                .HasForeignKey(s => s.VenueId);
        }
    }

}
