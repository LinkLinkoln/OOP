using TicketReservation.Core.Models;

public interface ITicketService
{
    Task<IEnumerable<Ticket>> GetAllTicketsAsync();
    Task<Ticket> GetTicketByIdAsync(Guid id);
    Task CreateTicketAsync(Ticket ticket);
    Task UpdateTicketAsync(Ticket ticket);
    Task DeleteTicketAsync(Guid id);
}

public class TicketService : ITicketService
{
    private readonly IGenericRepository<Ticket> _ticketRepository;

    public TicketService(IGenericRepository<Ticket> ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<IEnumerable<Ticket>> GetAllTicketsAsync() =>
        await _ticketRepository.GetAllAsync();

    public async Task<Ticket> GetTicketByIdAsync(Guid id) =>
        await _ticketRepository.GetByIdAsync(id);

    public async Task CreateTicketAsync(Ticket ticket) =>
        await _ticketRepository.CreateAsync(ticket);

    public async Task UpdateTicketAsync(Ticket ticket) =>
        await _ticketRepository.UpdateAsync(ticket);

    public async Task DeleteTicketAsync(Guid id) =>
        await _ticketRepository.DeleteAsync(id);


}
