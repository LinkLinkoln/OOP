namespace TicketReservation.Core.Models
{
    public class Venue
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }

        public ICollection<Event> Events { get; set; } // Связь с Event
        public ICollection<Seat> Seats { get; set; } // Связь с Seat
    }
}
