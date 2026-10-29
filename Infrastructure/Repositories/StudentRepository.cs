using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class StudentRepository(AppDbContext context) : IStudentRepository
{
    private readonly AppDbContext _context=context;
    public bool AddStudent(Student student)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"insert into students(FullName, Email, 
        Phone, EnrollmentDate) values
        (@FullName, @Email, @Phone, @EnrollmentDate)";
        int rowsAdded = connection.Execute(query,student);
        return rowsAdded > 0;
    }

    public bool DeleteStudent(int studentId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from students where StudentId = @StudentId";
        int rowsChanged = connection.Execute(query,new{studentId});
        return rowsChanged > 00;
    }

    public List<Student> GetDroppedOutStudents()
    {
        using var connection = _context.Connection();
        var query = @"SELECT DISTINCT s.*
        FROM students s
        JOIN studentgroups sg ON sg.StudentId = s.StudentId
        WHERE sg.Status = 'Отчислен'
        ORDER BY s.StudentId";
        return connection.Query<Student>(query).ToList();
    }

    public List<Student> GetGraduatedStudents()
    {
        using var connection = _context.Connection();
        var query = @"SELECT DISTINCT s.*
        FROM students s
        JOIN studentgroups sg ON sg.StudentId = s.StudentId
        JOIN groups g ON g.GroupId = sg.GroupId
        WHERE g.EndDate < CURRENT_DATE
          AND sg.Status <> 'Отчислен'
        ORDER BY s.StudentId";
        return connection.Query<Student>(query).ToList();
    }


    public Student GetStudent(int studentId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from students where StudentId = @StudentId";
        return connection.QueryFirst<Student>(query,new{studentId});
    }

    public List<Student> GetStudents()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from students";
        return connection.Query<Student>(query).ToList();
    }

    public List<StudentWithGroup> GetStudentsWithGroups()
    {
        using var connection = _context.Connection();
        var query = @"SELECT s.StudentId, s.FullName, g.GroupId, g.GroupName, sg.Status
        FROM students s
        JOIN studentgroups sg ON sg.StudentId = s.StudentId
        JOIN groups g ON g.GroupId = sg.GroupId
        ORDER BY s.StudentId, g.GroupId";
        return connection.Query<StudentWithGroup>(query).ToList();
    }

    public List<Student> GetStudentsWithoutGroups()
    {
        using var connection = _context.Connection();
        var query = @"SELECT s.*
        FROM students s
        WHERE NOT EXISTS (
            SELECT 1 FROM studentgroups sg WHERE sg.StudentId = s.StudentId
        )
        ORDER BY s.StudentId";
        return connection.Query<Student>(query).ToList();
    }


    public bool UpdateStudent(Student student)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"update students set FullName = @FullName, 
        Email = @Email, Phone = @Phone, EnrollmentDate = @EnrollmentDate
        where StudentId = @StudentId";
        int rowsChanged = connection.Execute(query, student);
        return rowsChanged > 0;
    }

}
