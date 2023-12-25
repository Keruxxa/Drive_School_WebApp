using API.Server.Models;

namespace API.Server.Interfaces
{
    public interface IPracticalExamRepository
    {
        Task<ICollection<PracticalExam>> GetPracticalExamsAsync();

        Task<PracticalExam> GetPracticalExamByIdAsync(int practicalExamId);

        Task<bool> PracticalExamExistsAsync(int practicalExamId);

        Task<bool> AddPracticalExamAsync(PracticalExam practicalExam);

        Task<bool> UpdatePracticalExamAsync(PracticalExam practicalExam);

        Task<bool> DeletePracticalExamAsync(PracticalExam practicalExam);

        Task<bool> SaveAsync();
    }
}
