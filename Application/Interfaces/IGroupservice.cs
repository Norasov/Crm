using Domain.Models;
namespace Application.Interfaces;

public interface IGroupservice
{
    void AddGroup(Group group);
    void UpdateGroup(Group group);
    void DeleteGroup(int groupId);
    void GetGroup(int groupId);
    void GetAllGroups();
    void GetStudentsPerGroup();
    void GetemptyGroups();
}
