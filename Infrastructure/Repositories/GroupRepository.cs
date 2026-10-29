using Domain.Models;
using Dapper;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class GroupRepository(AppDbContext context) : IGroupRepository
{
    private readonly AppDbContext _context = context;
    public bool AddGroup(Group group)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"insert into groups(GroupName, CourseId, MentorId, StartDate, EndDate) values
        (@GroupName, @CourseId, @MentorId, @StartDate, @EndDate)";
        int rowsAdded = connection.Execute(query,group);
        return rowsAdded > 0;
    }

    public bool DeleteGroup(int groupId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from groups where GroupId = @GroupId";
        int rowsChanged = connection.Execute(query,new{groupId});
        return rowsChanged > 0;
    }

    public List<Group> GetEmptyGroups()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select g.* from groups g
        where not exists (
            select 1 from studentgroups sg where sg.GroupId = g.GroupId
            )";
        return connection.Query<Group>(query).ToList();
    }


    public Group GetGroup(int groupId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from groups where GroupId = @GroupId";
        return connection.QueryFirst<Group>(query,new{groupId});
    }

    public List<Group> GetGroups()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from groups";
        return connection.Query<Group>(query).ToList();
    }

    public List<GroupStudentCount> GetStudentsPerGroup()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select g.GroupId, g. GroupName, count(sg.StudentId) as StudentCount
        from groups g
        left join studentgroups sg on sg.GroupId = g.GroupId
        group by g.GroupId, g. GroupName
        order by g.GroupId";
        return connection.Query<GroupStudentCount>(query).ToList();
    }


    public bool UpdateGroup(Group group)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"update groups set GroupName=@GroupName, CourseId=@CourseId, MentorId=@MentorId,
        StartDate=@StartDate, EndDate=@EndDate
        where GroupId = @GroupId";
        int rowsChanged = connection.Execute(query,new{group});
        return rowsChanged > 0;
    }

}
