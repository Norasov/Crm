using Domain.Models;

namespace Domain.Interfaces;

public interface IStudentGroupRepository
{
    Task<bool> AddStudentGroupAsync(StudentGroup studentGroup);
    Task<bool> DeleteStudentGroupAsync(int studentGroupId);
    Task<bool> UpdateStudentGroupAsync(StudentGroup studentGroup);
    Task<StudentGroup?> GetStudentGroupAsync(int studentGroupId);
    Task<List<StudentGroup>> GetStudentGroupsAsync();
}
