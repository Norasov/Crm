using Domain.Models;

namespace Domain.Interfaces;

public interface IStudentRepository
{
    Task<bool> AddStudentAsync(Student student);
    Task<bool> DeleteStudentAsync(int studentId);
    Task<bool> UpdateStudentAsync(Student student);
    Task<Student?> GetStudentAsync(int studentId);
    Task<List<Student>> GetStudentsAsync();
    Task<List<StudentWithGroup>> GetStudentsWithGroupsAsync();
    Task<List<Student>> GetStudentsWithoutGroupsAsync();
    Task<List<Student>> GetDroppedOutStudentsAsync();
    Task<List<Student>> GetGraduatedStudentsAsync();
}
