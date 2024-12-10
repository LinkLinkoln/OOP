namespace TicketReservation.Contracts
{
    public record UsersResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber);
}
