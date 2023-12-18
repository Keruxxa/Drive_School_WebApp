using API.Server.Models;

namespace API.Server.Interfaces
{
    public interface IReviewRepository
    {
        Task<ICollection<Review>> GetReviewsAsync();

        Task<Review> GetByIdAsync(int reviewId);

        Task<bool> ReviewExistsAsync(int reviewId);

        Task<bool> AddReviewAsync(Review review);

        Task<bool> UpdateReviewAsync(Review review);

        Task<bool> DeleteReviewAsync(Review review);

        Task<bool> SaveAsync();
    }
}
