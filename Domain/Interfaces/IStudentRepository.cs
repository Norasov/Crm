using Domain.Models;

namespace Domain.Interfaces;

public interface IStudentRepository
{
    bool AddStudent(Student student);
    bool DeleteStudent(int studentId);
    bool UpdateStudent(Student student);
    Student GetStudent(int studentId);
    List<Student> GetStudents();
    List<StudentWithGroup> GetStudentsWithGroups();
    List<Student> GetStudentsWithoutGroups();
    List<Student> GetDroppedOutStudents();
    List<Student> GetGraduatedStudents();
}
