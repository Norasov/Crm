using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class StudentRepository(AppDbContext context) : IStudentRepository
{
    private readonly AppDbContext _context=context;
    public async Task<bool> AddStudentAsync(Student student)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"insert into students(FullName, Email, 
        Phone, EnrollmentDate) values
        (@FullName, @Email, @Phone, @EnrollmentDate)";
        int rowsAdded = await connection.ExecuteAsync(query,student);
        return rowsAdded > 0;
    }

    public async Task<bool> DeleteStudentAsync(int studentId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from students where StudentId = @StudentId";
        int rowsChanged = await connection.ExecuteAsync(query,new{studentId});
        return rowsChanged > 00;
    }

    public async Task<List<Student>> GetDroppedOutStudentsAsync()
    {
        using var connection = _context.Connection();
        var query = @"SELECT DISTINCT s.*
        FROM students s
        JOIN studentgroups sg ON sg.StudentId = s.StudentId
        WHERE sg.Status = 'Отчислен'
        ORDER BY s.StudentId";
        var list = await connection.QueryAsync<Student>(query);
        return list.ToList();
    }

    public async Task<List<Student>> GetGraduatedStudentsAsync()
    {
        using var connection = _context.Connection();
        var query = @"SELECT DISTINCT s.*
        FROM students s
        JOIN studentgroups sg ON sg.StudentId = s.StudentId
        JOIN groups g ON g.GroupId = sg.GroupId
        WHERE g.EndDate < CURRENT_DATE
          AND sg.Status <> 'Отчислен'
        ORDER BY s.StudentId";
        var list = await connection.QueryAsync<Student>(query);
        return list.ToList();
    }


    public async Task<Student?> GetStudentAsync(int studentId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from students where StudentId = @StudentId";
        return await connection.QueryFirstOrDefaultAsync<Student>(query,new{studentId});
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from students";
        var list = await connection.QueryAsync<Student>(query);
        return list.ToList();
    }

    public async Task<List<StudentWithGroup>> GetStudentsWithGroupsAsync()
    {
        using var connection = _context.Connection();
        var query = @"SELECT s.StudentId, s.FullName, g.GroupId, g.GroupName, sg.Status
        FROM students s
        JOIN studentgroups sg ON sg.StudentId = s.StudentId
        JOIN groups g ON g.GroupId = sg.GroupId
        ORDER BY s.StudentId, g.GroupId";
        var list = await connection.QueryAsync<StudentWithGroup>(query);
        return list.ToList();
    }

    public async Task<List<Student>> GetStudentsWithoutGroupsAsync()
    {
        using var connection = _context.Connection();
        var query = @"SELECT s.*
        FROM students s
        WHERE NOT EXISTS (
            SELECT 1 FROM studentgroups sg WHERE sg.StudentId = s.StudentId
        )
        ORDER BY s.StudentId";
        var list = await connection.QueryAsync<Student>(query);
        return list.ToList();
    }


    public async Task<bool> UpdateStudentAsync(Student student)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"update students set FullName = @FullName, 
        Email = @Email, Phone = @Phone, EnrollmentDate = @EnrollmentDate
        where StudentId = @StudentId";
        int rowsChanged = await connection.ExecuteAsync(query, student);
        return rowsChanged > 0;
    }

}
