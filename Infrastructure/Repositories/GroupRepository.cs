using Domain.Models;
using Dapper;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class GroupRepository(AppDbContext context) : IGroupRepository
{
    private readonly AppDbContext _context = context;
    public async Task<bool> AddGroupAsync(Group group)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"insert into groups(GroupName, CourseId, MentorId, StartDate, EndDate) values
        (@GroupName, @CourseId, @MentorId, @StartDate, @EndDate)";
        int rowsAdded = await connection.ExecuteAsync(query,group);
        return rowsAdded > 0;
    }

    public async Task<bool> DeleteGroupAsync(int groupId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from groups where GroupId = @GroupId";
        int rowsChanged = await connection.ExecuteAsync(query,new{groupId});
        return rowsChanged > 0;
    }

    public async Task<List<Group>> GetEmptyGroupsAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select g.* from groups g
        where not exists (
            select 1 from studentgroups sg where sg.GroupId = g.GroupId
            )";
        var list = await connection.QueryAsync<Group>(query);
        return list.ToList();
    }


    public async Task<Group?> GetGroupAsync(int groupId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from groups where GroupId = @GroupId";
        return await connection.QueryFirstOrDefaultAsync<Group>(query,new{groupId});
    }

    public async Task<List<Group>> GetGroupsAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from groups";
        var list = await connection.QueryAsync<Group>(query);
        return list.ToList();
    }

    public async Task<List<GroupStudentCount>> GetStudentsPerGroupAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select g.GroupId, g. GroupName, count(sg.StudentId) as StudentCount
        from groups g
        left join studentgroups sg on sg.GroupId = g.GroupId
        group by g.GroupId, g. GroupName
        order by g.GroupId";
        var list =await connection.QueryAsync<GroupStudentCount>(query);
        return list.ToList();
    }


    public async Task<bool> UpdateGroupAsync(Group group)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"update groups set GroupName=@GroupName, CourseId=@CourseId, MentorId=@MentorId,
        StartDate=@StartDate, EndDate=@EndDate
        where GroupId = @GroupId";
        int rowsChanged = await connection.ExecuteAsync(query,group);
        return rowsChanged > 0;
    }
}
