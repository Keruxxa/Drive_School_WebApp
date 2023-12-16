using ReactApp.Server.Models;

namespace API.Server.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAllAsync();

        public Task<User> GetByIdAsync(Guid id);

        public Task AddAsync(User user);

        public Task Update(User user);

        public Task Delete(Guid id);
    }
}
