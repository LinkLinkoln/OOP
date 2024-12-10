namespace TicketReservation.Contracts
{
    public record UsersRequest(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber);
}
