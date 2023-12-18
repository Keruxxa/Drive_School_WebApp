using API.Server.Interfaces;
using API.Server.Models;
using Microsoft.EntityFrameworkCore;
using ReactApp.Server.Data;

namespace API.Server.Repositories
{
    public class PracticalExamRepository : IPracticalExamRepository
    {
        private readonly DataContext _context;

        public PracticalExamRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<ICollection<PracticalExam>> GetPracticalExamsAsync()
        {
            return await _context.PracticalExams.ToListAsync();
        }

        public async Task<PracticalExam> GetByIdAsync(int practicalExamId)
        {
            return await _context.PracticalExams.Where(p => p.Id == practicalExamId).FirstOrDefaultAsync();
        }

        public async Task<bool> PracticalExamExistsAsync(int practicalExamId)
        {
            return await _context.PracticalExams.AnyAsync(p => p.Id == practicalExamId);
        }

        public async Task<bool> AddPracticalExamAsync(PracticalExam practicalExam)
        {
            await _context.PracticalExams.AddAsync(practicalExam);
            return await SaveAsync();
        }

        public async Task<bool> DeletePracticalExamAsync(PracticalExam practicalExam)
        {
            _context.PracticalExams.Remove(practicalExam);
            return await SaveAsync();
        }

        public async Task<bool> UpdatePracticalExamAsync(PracticalExam practicalExam)
        {
            _context.PracticalExams.Update(practicalExam);
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }
    }
}
