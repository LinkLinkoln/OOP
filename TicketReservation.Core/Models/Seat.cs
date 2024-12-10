namespace TicketReservation.Core.Models
{
    public class Seat
    {
        public Guid Id { get; set; }
        public Guid VenueId { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }

        public Venue Venue { get; set; } // Связь с Venue
        public ICollection<Ticket> Tickets { get; set; } // Связь с Ticket
    }
}
