using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class StudentGroupRepository(AppDbContext context) : IStudentGroupRepository
{
    private readonly AppDbContext _context = context;
    public async Task<bool> AddStudentGroupAsync(StudentGroup studentGroup)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"insert into studentgroups(StudentId, GroupId, Status) values
        (@StudentId, @GroupId, @Status)";
        int rowsAdded = await connection.ExecuteAsync(query, studentGroup);
        return rowsAdded > 0;
    }

    public async Task<bool> DeleteStudentGroupAsync(int studentGroupId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from studentgroups where StudentGroupId = @StudentGroupId";
        int rowsChanged = await connection.ExecuteAsync(query,new{studentGroupId});
        return rowsChanged > 0;
    }

    public async Task<StudentGroup?> GetStudentGroupAsync(int studentGroupId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from StudentGroups where StudentGroupId = @StudentGroupId";
        return await connection.QueryFirstOrDefaultAsync<StudentGroup>(query,new{studentGroupId});
    }

    public async Task<List<StudentGroup>> GetStudentGroupsAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from StudentGroups";
        var list = await connection.QueryAsync<StudentGroup>(query);
        return list.ToList();
    }

    public async Task<bool> UpdateStudentGroupAsync(StudentGroup studentGroup)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"update studentgroups set StudentId = @StudentId, 
        GroupId = @GroupId,
        Status= @Status 
        where StudentGroupId = @StudentGroupId";
        int rowsChanged = await connection.ExecuteAsync(query,studentGroup);
        return rowsChanged > 0;
    }
}
