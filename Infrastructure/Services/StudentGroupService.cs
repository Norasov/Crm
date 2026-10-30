using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class StudentGroupService(StudentGroupRepository repository) : IStudentGroupservice
{
    private readonly StudentGroupRepository _repository = repository;
    public async Task AddStudentGroupAsync(StudentGroup studentGroup)
    {
        var addStudentGroup = await _repository.AddStudentGroupAsync(studentGroup);
        System.Console.WriteLine(addStudentGroup ? "Added successfuly!" : "Something went wrong!");
    }

    public async Task DeleteStudentGroupAsync(int studentGroupId)
    {
        var deleteStudentGroup = await _repository.DeleteStudentGroupAsync(studentGroupId);
        System.Console.WriteLine(deleteStudentGroup ? "Deleted successfuly!" : "Something went wrong!");
    }

    public async Task GetAllStudentGroupsAsync()
    {
        var getStudentGroups = await _repository.GetStudentGroupsAsync();
        foreach (var item in getStudentGroups)
        {
            System.Console.WriteLine(item.StudentGroupId + " | " + item.StudentId + " | " + item.GroupId + " | " + item.Status);
        }
    }

    public async Task GetStudentGroupAsync(int studentGroupId)
    {
        var getStudentGroup = await _repository.GetStudentGroupAsync(studentGroupId);
        if(getStudentGroup is null) System.Console.WriteLine("Не найден!");
        else System.Console.WriteLine(getStudentGroup.StudentGroupId + " | " + getStudentGroup.StudentId + " | " + getStudentGroup.GroupId + " | " + getStudentGroup.Status);
    }

    public async Task UpdateStudentGroupAsync(StudentGroup studentGroup)
    {
        var updategetStudentGroup = await _repository.UpdateStudentGroupAsync(studentGroup);
        System.Console.WriteLine(updategetStudentGroup ? "Updated successfuly!" : "Something went wrong!");
    }
}
