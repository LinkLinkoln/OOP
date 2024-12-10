using Microsoft.EntityFrameworkCore;
using TicketReservation.Core.Models;
using TicketReservation.DataAccess.Entities;

namespace TicketReservation.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly TicketReservationDbContext _context;

        public UsersRepository(TicketReservationDbContext context)
        {
            _context = context;

        }
        public async Task<List<User>> Get()
        {
            var userEntities = await _context.Users.AsNoTracking().ToListAsync();

            var users = userEntities.Select(b => User.Create(b.Id, b.FirstName, b.LastName, b.Email, b.Phone).User).ToList();

            return users;
        }

        public async Task<Guid> Create(User user)
        {
            var bookEntity = new UserEntity
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
            };
            await _context.Users.AddAsync(bookEntity);
            await _context.SaveChangesAsync();

            return bookEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string firstName, string lastName, string email, string phone)
        {
            await _context.Users.Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s.
                SetProperty(b => b.FirstName, b => firstName)
                .SetProperty(b => b.LastName, b => lastName)
                .SetProperty(b => b.Email, b => email)
                .SetProperty(b => b.Phone, b => phone));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Users.
                Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
