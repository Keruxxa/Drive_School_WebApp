using Microsoft.EntityFrameworkCore;
using ReactApp.Server.Data;
using ReactApp.Server.Models;

namespace ReactApp.Server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _userDbContext;

        public UserService(UserDbContext userDbContext)
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

        public async Task AddAsync(User user)
        {
            await _userDbContext.Users.AddAsync(user);

            await _userDbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var user = _userDbContext.Users.FirstOrDefault(u => u.Id == id);
            _userDbContext.Users.Remove(user);

            await _userDbContext.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _userDbContext.Users.Update(user);

            await _userDbContext.SaveChangesAsync();
        }
    }
}
