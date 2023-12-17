using ReactApp.Server.Models;

namespace API.Server.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAllAsync();

        public Task<User> GetByIdAsync(Guid id);

        public Task<bool> AddAsync(User user);

        public Task<bool> Update(User user);

        public Task Delete(Guid id);

        public Task<bool> SaveAsync();
    }
}
