using Domain.Models;

namespace Domain.Interfaces;

public interface IStudentGroupRepository
{
    bool AddStudentGroup(StudentGroup studentGroup);
    bool DeleteStudentGroup(int studentGroupId);
    bool UpdateStudentGroup(StudentGroup studentGroup);
    StudentGroup GetStudentGroup(int studentGroupId);
    List<StudentGroup> GetStudentGroups();
}
