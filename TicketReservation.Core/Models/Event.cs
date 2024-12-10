namespace TicketReservation.Core.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Guid VenueId { get; set; }
        public int TotalSeats { get; set; }

        public Venue Venue { get; set; } // Связь с Venue
        public ICollection<Ticket> Tickets { get; set; } // Связь с Ticket
    }
}
