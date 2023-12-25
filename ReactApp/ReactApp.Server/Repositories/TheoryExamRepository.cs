using API.Server.Interfaces;
using API.Server.Models;
using Microsoft.EntityFrameworkCore;
using ReactApp.Server.Data;

namespace API.Server.Repositories
{
    public class TheoryExamRepository : ITheoryExamRepository
    {
        private readonly DataContext _context;

        public TheoryExamRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<TheoryExam>> GetTheoryExamsAsync()
        {
            return await _context.TheoryExams.ToListAsync();
        }

        public async Task<TheoryExam> GetTheoryExamByIdAsync(int theoryExamId)
        {
            return await _context.TheoryExams.Where(t => t.Id == theoryExamId).FirstOrDefaultAsync();
        }

        public async Task<bool> TheoryExamExistsAsync(int theoryExamId)
        {
            return await _context.TheoryExams.AnyAsync(t => t.Id == theoryExamId);
        }

        public async Task<bool> AddTheoryExamAsync(TheoryExam theoryExam)
        {
            await _context.TheoryExams.AddAsync(theoryExam);
            return await SaveAsync();
        }

        public async Task<bool> DeleteTheoryExamAsync(TheoryExam theoryExam)
        {
            _context.TheoryExams.Remove(theoryExam);
            return await SaveAsync();
        }

        public async Task<bool> UpdateTheoryExamAsync(TheoryExam theoryExam)
        {
            _context.TheoryExams.Update(theoryExam);
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }
    }
}
