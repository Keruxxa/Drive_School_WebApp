using API.Server.Models;

namespace API.Server.Interfaces
{
    public interface ITeacherRepository
    {
        Task<ICollection<Teacher>> GetTeachersAsync();

        Task<Teacher> GetTeacherByIdAsync(int teacherId);

        Task<bool> TeacherExistsAsync(int teacherId);

        Task<bool> AddTeacherAsync(Teacher teacher);

        Task<bool> UpdateTeacherAsync(Teacher teacher);

        Task<bool> DeleteTeacherAsync(Teacher teacher);

        Task<bool> SaveAsync();
    }
}
