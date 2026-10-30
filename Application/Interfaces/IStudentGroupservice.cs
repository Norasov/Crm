using Domain.Models;

namespace Application.Interfaces;

public interface IStudentGroupservice
{
    Task AddStudentGroupAsync(StudentGroup studentGroup);
    Task UpdateStudentGroupAsync(StudentGroup studentGroup);
    Task DeleteStudentGroupAsync(int studentGroupId);
    Task GetStudentGroupAsync(int studentGroupId);
    Task GetAllStudentGroupsAsync();
}
