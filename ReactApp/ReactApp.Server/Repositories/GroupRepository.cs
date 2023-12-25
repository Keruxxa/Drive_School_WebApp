using API.Server.Interfaces;
using API.Server.Models;
using Microsoft.EntityFrameworkCore;
using ReactApp.Server.Data;

namespace API.Server.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DataContext _context;

        public GroupRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<ICollection<Group>> GetGroupsAsync()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<Group> GetGroupByIdAsync(int groupId)
        {
            return await _context.Groups.Where(g => g.Id == groupId).FirstOrDefaultAsync();
        }

        public async Task<bool> GroupExistsAsync(int groupId)
        {
            return await _context.Groups.AnyAsync(g => g.Id == groupId);
        }

        public async Task<bool> AddGroupAsync(Group group)
        {
            await _context.Groups.AddAsync(group);
            return await SaveAsync();
        }

        public async Task<bool> DeleteGroupAsync(Group group)
        {
            _context.Groups.Remove(group);
            return await SaveAsync();
        }

        public async Task<bool> UpdateGroupAsync(Group group)
        {
            _context.Groups.Update(group);
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }
    }
}
