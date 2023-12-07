using ReactApp.Server.Models;

namespace ReactApp.Server.Services.UserService
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAllAsync();

        public Task<User> GetByIdAsync(Guid id);

        public Task AddAsync(User user);

        public Task Update(User user);

        public Task Delete(Guid id);
    }
}
