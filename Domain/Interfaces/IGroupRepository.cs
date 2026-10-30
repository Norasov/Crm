using Domain.Models;

namespace Domain.Interfaces;

public interface IGroupRepository
{
    Task<bool> AddGroupAsync(Group group);
    Task<bool> UpdateGroupAsync(Group group);
    Task<bool> DeleteGroupAsync(int groupId);
    Task<Group?> GetGroupAsync(int groupId);
    Task<List<Group>> GetGroupsAsync();
    Task<List<GroupStudentCount>> GetStudentsPerGroupAsync();
    Task<List<Group>> GetEmptyGroupsAsync();
}
