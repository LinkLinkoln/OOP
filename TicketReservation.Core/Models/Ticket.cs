namespace TicketReservation.Core.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
        public Guid SeatId { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }

        public Event Event { get; set; }
        public User User { get; set; } 
        public Seat Seat { get; set; } 
    }
}
