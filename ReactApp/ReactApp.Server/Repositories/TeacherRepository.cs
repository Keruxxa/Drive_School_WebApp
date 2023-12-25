using API.Server.Interfaces;
using API.Server.Models;
using Microsoft.EntityFrameworkCore;
using ReactApp.Server.Data;

namespace API.Server.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DataContext _context;

        public TeacherRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Teacher>> GetTeachersAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetTeacherByIdAsync(int teacherId)
        {
            return await _context.Teachers.Where(t => t.Id == teacherId).FirstOrDefaultAsync();
        }

        public async Task<bool> TeacherExistsAsync(int teacherId)
        {
            return await _context.Teachers.AnyAsync(t => t.Id == teacherId);
        }

        public async Task<bool> AddTeacherAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            return await SaveAsync();
        }

        public async Task<bool> DeleteTeacherAsync(Teacher teacher)
        {
            _context.Teachers.Remove(teacher);
            return await SaveAsync();
        }

        public async Task<bool> UpdateTeacherAsync(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            foreach (var entry in _context.ChangeTracker.Entries<Teacher>())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    var teacher = entry.Entity;

                    if (teacher.Experience < 5)
                    {
                        return false;
                    }
                }
            }
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }
    }
}
