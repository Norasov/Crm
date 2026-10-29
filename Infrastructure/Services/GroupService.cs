using Domain.Models;
using Application.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class GroupService(GroupRepository repository) : IGroupservice
{
    private readonly GroupRepository _repository = repository;
    public void AddGroup(Group group)
    {
        var addGroup = _repository.AddGroup(group);
        System.Console.WriteLine(addGroup ? "Added successfuly!" : "Something went wrong!");
    }

    public void DeleteGroup(int groupId)
    {
        var deleteGroup = _repository.DeleteGroup(groupId);
        System.Console.WriteLine(deleteGroup ? "Deleted successfuly!" : "Something went wrong!");
    }

    public void GetAllGroups()
    {
        var getGroups = _repository.GetGroups();
        foreach (var item in getGroups)
        {
            System.Console.WriteLine(item.GroupId + " | " + item.GroupName + " | " + item.CourseId + " | " + item.MentorId + " | " + item.StartDate + " | " + item.EndDate);
        }
    }

    public void GetemptyGroups()
    {
        var getEmptyGroups = _repository.GetEmptyGroups();
        foreach (var item in getEmptyGroups)
        {
            System.Console.WriteLine(item.GroupId + " | " + item.GroupName + " | " + item.CourseId + " | " + item.MentorId + " | " + item.StartDate + " | " + item.EndDate);
        }
    }


    public void GetGroup(int groupId)
    {
        var getGroup = _repository.GetGroup(groupId);
        System.Console.WriteLine(getGroup.GroupId + " | " + getGroup.GroupName + " | " + getGroup.CourseId + " | " + getGroup.MentorId + " | " + getGroup.StartDate + " | " + getGroup.EndDate);
    }

    public void GetStudentsPerGroup()
    {
        var getStudentsPerGroup = _repository.GetStudentsPerGroup();
        foreach (var item in getStudentsPerGroup)
        {
            System.Console.WriteLine(item.GroupId + " | "+item.GroupName + " | " + item.StudentCount);
        }
    }

    public void UpdateGroup(Group group)
    {
        var updateGroup = _repository.UpdateGroup(group);
        System.Console.WriteLine(updateGroup ? "Updated successfuly!" : "Something went wrong!");
    }
}
