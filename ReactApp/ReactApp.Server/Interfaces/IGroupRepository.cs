using API.Server.Models;

namespace API.Server.Interfaces
{
    public interface IGroupRepository
    {
        Task<ICollection<Group>> GetGroupsAsync();

        Task<Group> GetByIdAsync(int groupId);

        Task<bool> GroupExistsAsync(int groupId);

        Task<bool> AddGroupAsync(Group car);

        Task<bool> UpdateGroupAsync(Group car);

        Task<bool> DeleteGroupAsync(Group car);

        Task<bool> SaveAsync();
    }
}
