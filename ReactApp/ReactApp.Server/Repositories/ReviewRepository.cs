using API.Server.Interfaces;
using API.Server.Models;
using Microsoft.EntityFrameworkCore;
using ReactApp.Server.Data;

namespace API.Server.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<ICollection<Review>> GetReviewsAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review> GetReviewByIdAsync(int reviewId)
        {
            return await _context.Reviews.Where(r => r.Id == reviewId).FirstOrDefaultAsync();
        }

        public async Task<bool> ReviewExistsAsync(int reviewId)
        {
            return await _context.Reviews.AnyAsync(r => r.Id == reviewId);
        }

        public async Task<bool> AddReviewAsync(Review review, int studentId, int teacherId)
        {
            var student = await _context.Students.Where(s => s.Id == studentId).FirstOrDefaultAsync();

            var teacher = await _context.Teachers.Where(t => t.Id == teacherId).FirstOrDefaultAsync();

            review.Student = student;
            review.Teacher = teacher;

            await _context.Reviews.AddAsync(review);

            return await SaveAsync();
        }

        public async Task<bool> DeleteReviewAsync(Review review)
        {
            _context.Reviews.Remove(review);
            return await SaveAsync();
        }

        public async Task<bool> UpdateReviewAsync(Review review, int studentId, int teacherId)
        {
            var student = await _context.Students.Where(s => s.Id == studentId).FirstOrDefaultAsync();

            var teacher = await _context.Teachers.Where(t => t.Id == teacherId).FirstOrDefaultAsync();

            review.Student = student;
            review.Teacher = teacher;

            _context.Reviews.Update(review);

            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }
    }
}
