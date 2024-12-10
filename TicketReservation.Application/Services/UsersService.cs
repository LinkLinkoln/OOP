using TicketReservation.Core.Models;
using TicketReservation.DataAccess.Repositories;

namespace TicketReservation.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            this._usersRepository = usersRepository;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _usersRepository.Get();
        }

        public async Task<Guid> CreateUser(User user)
        {
            return await _usersRepository.Create(user);
        }
        public async Task<Guid> UpdateUser(Guid id, string firstName, string lastName, string email, string phone)
        {
            return await _usersRepository.Update(id, firstName, lastName, email, phone);
        }
        public async Task<Guid> DeleteUser(Guid id)
        {
            return await _usersRepository.Delete(id);
        }
    }
}
