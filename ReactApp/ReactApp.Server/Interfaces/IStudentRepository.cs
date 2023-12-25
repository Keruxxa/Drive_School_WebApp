﻿using API.Server.Models;

namespace API.Server.Interfaces
{
    public interface IStudentRepository
    {
        Task<ICollection<Student>> GetStudentsAsync();

        Task<Student> GetStudentByIdAsync(int studentId);

        Task<bool> StudentExistsAsync(int studentId);

        Task<bool> AddStudentAsync(Student student, int groupId);

        Task<bool> UpdateStudentAsync(Student student, int groupId);

        Task<bool> DeleteStudentAsync(Student student);

        Task<bool> SaveAsync();
    }
}
