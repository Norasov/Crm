using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class StudentGroupRepository(AppDbContext context) : IStudentGroupRepository
{
    private readonly AppDbContext _context = context;
    public bool AddStudentGroup(StudentGroup studentGroup)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"insert into studentgroups(StudentId, GroupId, Status) values
        (@StudentId, @GroupId, @Status)";
        int rowsAdded = connection.Execute(query, studentGroup);
        return rowsAdded > 0;
    }

    public bool DeleteStudentGroup(int studentGroupId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from studentgroups where StudentGroupId = @StudentGroupId";
        int rowsChanged = connection.Execute(query,new{studentGroupId});
        return rowsChanged > 0;
    }

    public StudentGroup GetStudentGroup(int studentGroupId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from StudentGroups where StudentGroupId = @StudentGroupId";
        return connection.QueryFirstOrDefault<StudentGroup>(query,new{studentGroupId})!;
    }

    public List<StudentGroup> GetStudentGroups()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from StudentGroups";
        return connection.Query<StudentGroup>(query).ToList();
    }

    public bool UpdateStudentGroup(StudentGroup studentGroup)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"update studentgroups set StudentId = @StudentId, 
        GroupId = @GroupId,
        Status= @Status 
        where StudentGroupId = @StudentGroupId";
        int rowsChanged = connection.Execute(query,new{studentGroup});
        return rowsChanged > 0;
    }

}
