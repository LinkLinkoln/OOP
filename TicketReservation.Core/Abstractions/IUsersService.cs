using TicketReservation.Core.Models;

namespace TicketReservation.Application.Services
{
    public interface IUsersService
    {
        Task<Guid> CreateUser(User user);
        Task<Guid> DeleteUser(Guid id);
        Task<List<User>> GetAllUsers();
        Task<Guid> UpdateUser(Guid id, string firstName, string lastName, string email, string phone);
    }
}