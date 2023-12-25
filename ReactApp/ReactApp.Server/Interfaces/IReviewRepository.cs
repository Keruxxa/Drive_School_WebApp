using API.Server.Models;

namespace API.Server.Interfaces
{
    public interface IReviewRepository
    {
        Task<ICollection<Review>> GetReviewsAsync();

        Task<Review> GetReviewByIdAsync(int reviewId);

        Task<bool> ReviewExistsAsync(int reviewId);

        Task<bool> AddReviewAsync(Review review, int studentId, int teacherId);

        Task<bool> UpdateReviewAsync(Review review, int studentId, int teacherId);

        Task<bool> DeleteReviewAsync(Review review);

        Task<bool> SaveAsync();
    }
}
