using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class CourseRepository(AppDbContext context) : ICourseRepository
{
    private readonly AppDbContext _context = context;
    public bool AddCourse(Course course)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"insert into Courses(Title, Description, DurationWeeks) values
        (@Title, @Description, @DurationWeeks)";
        int rowsAdded = connection.Execute(query, course);
        return rowsAdded > 0;
    }

    public bool DeleteCourse(int courseId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from courses where CourseId = @CourseId";
        int rowsChanged = connection.Execute(query, new { courseId });
        return rowsChanged > 0;
    }

    public Course GetCourse(int courseId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from courses where CourseId = @CourseId";
        return connection.QueryFirst<Course>(query, new { courseId });
    }

    public List<Course> GetCourses()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from courses";
        return connection.Query<Course>(query).ToList();
    }

    public List<CourseStudentCount> GetLeastPopularCourses()
    {
        using var connection = _context.Connection();
        var query = @"SELECT c.CourseId, c.CourseName, COUNT(DISTINCT sg.StudentId) AS StudentCount
        FROM courses c
        LEFT JOIN groups g ON g.CourseId = c.CourseId
        LEFT JOIN studentgroups sg ON sg.GroupId = g.GroupId
        GROUP BY c.CourseId, c.CourseName
        ORDER BY StudentCount ASC, c.CourseId
        LIMIT 3";
        return connection.Query<CourseStudentCount>(query).ToList();
    }

    public List<CourseStudentCount> GetMostPopularCourse()
    {
        using var connection = _context.Connection();
        var query = @"SELECT c.CourseId, c.CourseName, COUNT(DISTINCT sg.StudentId) AS StudentCount
        FROM courses c
        JOIN groups g ON g.CourseId = c.CourseId
        JOIN studentgroups sg ON sg.GroupId = g.GroupId
        GROUP BY c.CourseId, c.CourseName
        HAVING COUNT(DISTINCT sg.StudentId) = (
            SELECT MAX(cnt) FROM (
                SELECT COUNT(DISTINCT sg2.StudentId) AS cnt
                FROM groups g2
                JOIN studentgroups sg2 ON sg2.GroupId = g2.GroupId
                GROUP BY g2.CourseId
            ) t
        )";
        return connection.Query<CourseStudentCount>(query).ToList();
    }

    public List<CourseStudentCount> GetStudentsPerCourse()
    {
        using var connection = _context.Connection();
        var query = @"SELECT c.CourseId, c.CourseName, COUNT(DISTINCT sg.StudentId) AS StudentCount
        FROM courses c
        LEFT JOIN groups g ON g.CourseId = c.CourseId
        LEFT JOIN studentgroups sg ON sg.GroupId = g.GroupId
        GROUP BY c.CourseId, c.CourseName
        ORDER BY c.CourseId";
        return connection.Query<CourseStudentCount>(query).ToList();
    }

    public List<CourseStudentCount> GetTopThreeCourses()
    {
        using var connection = _context.Connection();
        var query = @"SELECT c.CourseId, c.Title as CourseName, COUNT(DISTINCT sg.StudentId) AS StudentCount
        FROM courses c
        LEFT JOIN groups g ON g.CourseId = c.CourseId
        LEFT JOIN studentgroups sg ON sg.GroupId = g.GroupId
        GROUP BY c.CourseId, c.Title
        ORDER BY StudentCount DESC, c.CourseId
        LIMIT 3";
        return connection.Query<CourseStudentCount>(query).ToList();
    }


    public bool UpdateCourse(Course course)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"update courses set Title=@Title, 
        Description=@Description, 
        DurationWeeks = @DurationWeeks
        where CourseId = @CourseId";
        int rowsChanged = connection.Execute(query, new { course });
        return rowsChanged > 0;
    }

}
