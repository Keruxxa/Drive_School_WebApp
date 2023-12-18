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

        public async Task<Student> GetByIdAsync(int studentId)
        {
            return await _context.Students.Where(s => s.Id == studentId).FirstOrDefaultAsync();
        }

        public async Task<bool> StudentExistsAsync(int studentId)
        {
            return await _context.Students.AnyAsync(s => s.Id == studentId);
        }

        public async Task<bool> AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            return await SaveAsync();
        }

        public async Task<bool> DeleteStudentAsync(Student student)
        {
            _context.Students.Remove(student);
            return await SaveAsync();
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
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
