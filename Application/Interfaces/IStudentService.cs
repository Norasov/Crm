using Domain.Models;

namespace Application.Interfaces;

public interface IStudentService
{
    Task AddStudentAsync(Student student);
    Task UpdateStudentAsync(Student student);
    Task DeleteStudentAsync(int studentId);
    Task GetStudentAsync(int studentId);
    Task GetAllStudentsAsync();
    Task GetStudentsWithGroupsAsync();
    Task GetStudentsWithoutGroupsAsync();
    Task GetDroppedOutStudentsAsync();
    Task GetGraduatedStudentsAsync();
}
