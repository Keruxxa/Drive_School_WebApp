using API.Server.Models;

namespace API.Server.Interfaces
{
    public interface IStudentRepository
    {
        Task<ICollection<Student>> GetStudentsAsync();

        Task<Student> GetByIdAsync(int studentId);

        Task<bool> StudentExistsAsync(int studentId);

        Task<bool> AddStudentAsync(Student student);

        Task<bool> UpdateStudentAsync(Student student);

        Task<bool> DeleteStudentAsync(Student student);

        Task<bool> SaveAsync();
    }
}
