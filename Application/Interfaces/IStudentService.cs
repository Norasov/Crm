using Domain.Models;

namespace Application.Interfaces;

public interface IStudentService
{
    void AddStudent(Student student);
    void UpdateStudent(Student student);
    void DeleteStudent(int studentId);
    void GetStudent(int studentId);
    void GetAllStudents();
    void GetStudentsWithGroups();
    void GetStudentsWithoutGroups();
    void GetDroppedOutStudents();
    void GetGraduatedStudents();
}
