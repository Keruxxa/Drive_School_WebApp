using API.Server.Interfaces;
using API.Server.Models;
using Microsoft.EntityFrameworkCore;
using ReactApp.Server.Data;

namespace API.Server.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<ICollection<Student>> GetStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }


        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            return await _context.Students.Where(s => s.Id == studentId).FirstOrDefaultAsync();
        }


        public async Task<bool> StudentExistsAsync(int studentId)
        {
            return await _context.Students.AnyAsync(s => s.Id == studentId);
        }


        public async Task<bool> AddStudentAsync(Student student, int groupId)
        {
            var group = await _context.Groups.Where(g => g.Id == groupId).FirstOrDefaultAsync();

            student.Group = group;

            await _context.AddAsync(student);

            return await SaveAsync();
        }


        public async Task<bool> DeleteStudentAsync(Student student)
        {
            _context.Students.Remove(student);
            return await SaveAsync();
        }


        public async Task<bool> UpdateStudentAsync(Student student, int groupId)
        {
            var group = await _context.Groups.Where(g => g.Id == groupId).FirstOrDefaultAsync();

            student.Group = group;

            _context.Students.Update(student);

            return await SaveAsync();
        }


        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }
    }
}
