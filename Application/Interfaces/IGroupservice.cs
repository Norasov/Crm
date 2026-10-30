using Domain.Models;
namespace Application.Interfaces;

public interface IGroupService
{
    Task AddGroupAsync(Group group);
    Task UpdateGroupAsync(Group group);
    Task DeleteGroupAsync(int groupId);
    Task GetGroupAsync(int groupId);
    Task GetAllGroupsAsync();
    Task GetStudentsPerGroupAsync();
    Task GetEmptyGroupsAsync();
}
