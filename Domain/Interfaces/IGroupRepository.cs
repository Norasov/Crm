using Domain.Models;

namespace Domain.Interfaces;

public interface IGroupRepository
{
    bool AddGroup(Group group);
    bool UpdateGroup(Group group);
    bool DeleteGroup(int groupId);
    Group GetGroup(int groupId);
    List<Group> GetGroups();
    List<GroupStudentCount> GetStudentsPerGroup();
    List<Group> GetEmptyGroups();
}
