using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class StudentGroupService(StudentGroupRepository repository) : IStudentGroupservice
{
    private readonly StudentGroupRepository _repository = repository;
    public void AddStudentGroup(StudentGroup studentGroup)
    {
        var addStudentGroup = _repository.AddStudentGroup(studentGroup);
        System.Console.WriteLine(addStudentGroup ? "Added successfuly!" : "Something went wrong!");
    }

    public void DeleteStudentGroup(int studentGroupId)
    {
        var deleteStudentGroup = _repository.DeleteStudentGroup(studentGroupId);
        System.Console.WriteLine(deleteStudentGroup ? "Deleted successfuly!" : "Something went wrong!");
    }

    public void GetAllStudentGroups()
    {
        var getStudentGroups = _repository.GetStudentGroups();
        foreach (var item in getStudentGroups)
        {
            System.Console.WriteLine(item.StudentGroupId + " | " + item.StudentId + " | " + item.GroupId + " | " + item.Status);
        }
    }

    public void GetStudentGroup(int studentGroupId)
    {
        var getStudentGroup = _repository.GetStudentGroup(studentGroupId);
        System.Console.WriteLine(getStudentGroup.StudentGroupId + " | " + getStudentGroup.StudentId + " | " + getStudentGroup.GroupId + " | " + getStudentGroup.Status);
    }

    public void UpdateStudentGroup(StudentGroup studentGroup)
    {
        var updategetStudentGroup = _repository.UpdateStudentGroup(studentGroup);
        System.Console.WriteLine(updategetStudentGroup ? "Updated successfuly!" : "Something went wrong!");
    }
}
