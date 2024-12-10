using TicketReservation.Core.Models;

namespace TicketReservation.Application.Services
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllEntities();
        Task<T> GetById(Guid id);
        Task<Guid> CreateEntity(T entity);
        Task<Guid> UpdateEntity(T entity);
        Task<Guid> DeleteEntity(Guid id);
    }

}