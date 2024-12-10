using Microsoft.AspNetCore.Mvc;
using TicketReservation.Core.Models;

[Route("api/[controller]")]
[ApiController]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketsController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTickets()
    {
        var tickets = await _ticketService.GetAllTicketsAsync();
        return Ok(tickets);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTicket(Guid id)
    {
        var ticket = await _ticketService.GetTicketByIdAsync(id);
        if (ticket == null)
            return NotFound();
        return Ok(ticket);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTicket([FromBody] Ticket ticket)
    {
        if (ticket == null)
            return BadRequest();

        await _ticketService.CreateTicketAsync(ticket);
        return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, ticket);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTicket(Guid id, [FromBody] Ticket ticket)
    {
        if (ticket == null || ticket.Id != id)
            return BadRequest();

        var existingTicket = await _ticketService.GetTicketByIdAsync(id);
        if (existingTicket == null)
            return NotFound();

        await _ticketService.UpdateTicketAsync(ticket);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTicket(Guid id)
    {
        var ticket = await _ticketService.GetTicketByIdAsync(id);
        if (ticket == null)
            return NotFound();

        await _ticketService.DeleteTicketAsync(id);
        return NoContent();
    }
}
