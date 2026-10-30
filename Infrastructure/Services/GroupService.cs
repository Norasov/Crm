using Domain.Models;
using Application.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class GroupService(GroupRepository repository) : IGroupService
{
    private readonly GroupRepository _repository = repository;
    public async Task AddGroupAsync(Group group)
    {
        var addGroup = await _repository.AddGroupAsync(group);
        System.Console.WriteLine(addGroup ? "Added successfuly!" : "Something went wrong!");
    }

    public async Task DeleteGroupAsync(int groupId)
    {
        var deleteGroup = await _repository.DeleteGroupAsync(groupId);
        System.Console.WriteLine(deleteGroup ? "Deleted successfuly!" : "Something went wrong!");
    }

    public async Task GetAllGroupsAsync()
    {
        var getGroups = await _repository.GetGroupsAsync();
        foreach (var item in getGroups)
        {
            System.Console.WriteLine(item.GroupId + " | " + item.GroupName + " | " + item.CourseId + " | " + item.MentorId + " | " + item.StartDate + " | " + item.EndDate);
        }
    }

    public async Task GetEmptyGroupsAsync()
    {
        var getEmptyGroups = await _repository.GetEmptyGroupsAsync();
        foreach (var item in getEmptyGroups)
        {
            System.Console.WriteLine(item.GroupId + " | " + item.GroupName + " | " + item.CourseId + " | " + item.MentorId + " | " + item.StartDate + " | " + item.EndDate);
        }
    }


    public async Task GetGroupAsync(int groupId)
    {
        var getGroup = await _repository.GetGroupAsync(groupId);
        if(getGroup is null) System.Console.WriteLine("Группа не найдена!");
        else System.Console.WriteLine(getGroup.GroupId + " | " + getGroup.GroupName + " | " + getGroup.CourseId + " | " + getGroup.MentorId + " | " + getGroup.StartDate + " | " + getGroup.EndDate);
    }

    public async Task GetStudentsPerGroupAsync()
    {
        var getStudentsPerGroup = await _repository.GetStudentsPerGroupAsync();
        foreach (var item in getStudentsPerGroup)
        {
            System.Console.WriteLine(item.GroupId + " | "+item.GroupName + " | " + item.StudentCount);
        }
    }

    public async Task UpdateGroupAsync(Group group)
    {
        var updateGroup = await _repository.UpdateGroupAsync(group);
        System.Console.WriteLine(updateGroup ? "Updated successfuly!" : "Something went wrong!");
    }
}
