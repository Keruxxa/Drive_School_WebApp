using API.Server.Models;

namespace API.Server.Interfaces
{
    public interface ITheoryExamRepository
    {
        Task<ICollection<TheoryExam>> GetTheoryExamsAsync();

        Task<TheoryExam> GetTheoryExamByIdAsync(int theoryExamId);

        Task<bool> TheoryExamExistsAsync(int theoryExamId);

        Task<bool> AddTheoryExamAsync(TheoryExam theoryExam);

        Task<bool> UpdateTheoryExamAsync(TheoryExam theoryExam);

        Task<bool> DeleteTheoryExamAsync(TheoryExam theoryExam);

        Task<bool> SaveAsync();
    }
}
