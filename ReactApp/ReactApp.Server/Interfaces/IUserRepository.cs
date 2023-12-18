using ReactApp.Server.Models;

namespace API.Server.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetByIdAsync(Guid id);

        Task<bool> AddAsync(User user);

        Task<bool> Update(User user);

        Task Delete(Guid id);

        Task<bool> SaveAsync();
    }
}
