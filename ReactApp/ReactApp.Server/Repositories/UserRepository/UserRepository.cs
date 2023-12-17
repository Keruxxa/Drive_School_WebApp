using API.Server.Interfaces;
using Microsoft.EntityFrameworkCore;
using ReactApp.Server.Data;
using ReactApp.Server.Models;

namespace ReactApp.Server.Services.UserService
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _userDbContext;

        public UserRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }


        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userDbContext.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _userDbContext.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> AddAsync(User user)
        {
            await _userDbContext.Users.AddAsync(user);

            return await SaveAsync();
        }

        public async Task Delete(Guid id)
        {
            var user = _userDbContext.Users.FirstOrDefault(u => u.Id == id);
            _userDbContext.Users.Remove(user);

            await _userDbContext.SaveChangesAsync();
        }

        public async Task<bool> Update(User user)
        {
            _userDbContext.Users.Update(user);

            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _userDbContext.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
