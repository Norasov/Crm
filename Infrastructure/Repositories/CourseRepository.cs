using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class CourseRepository(AppDbContext context) : ICourseRepository
{
    private readonly AppDbContext _context = context;
    public async Task<bool> AddCourseAsync(Course course)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"insert into Courses(Title, Description, DurationWeeks) values
        (@Title, @Description, @DurationWeeks)";
        int rowsAdded = await connection.ExecuteAsync(query, course);
        return rowsAdded > 0;
    }

    public async Task<bool> DeleteCourseAsync(int courseId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from courses where CourseId = @CourseId";
        int rowsChanged = await connection.ExecuteAsync(query, new { courseId });
        return rowsChanged > 0;
    }

    public async Task<Course?> GetCourseAsync(int courseId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from courses where CourseId = @CourseId";
        return await connection.QueryFirstOrDefaultAsync<Course>(query, new { courseId });
    }

    public async Task<List<Course>> GetCoursesAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from courses";
        var list = await connection.QueryAsync<Course>(query);
        return list.ToList();
    }

    public async Task<List<CourseStudentCount>> GetLeastPopularCoursesAsync()
    {
        using var connection = _context.Connection();
        var query = @"SELECT c.CourseId, c.Title, COUNT(DISTINCT sg.StudentId) AS StudentCount
        FROM courses c
        LEFT JOIN groups g ON g.CourseId = c.CourseId
        LEFT JOIN studentgroups sg ON sg.GroupId = g.GroupId
        GROUP BY c.CourseId, c.Title
        ORDER BY StudentCount ASC, c.CourseId
        LIMIT 3";
        var list = await connection.QueryAsync<CourseStudentCount>(query);
        return list.ToList();
    }

    public async Task<List<CourseStudentCount>> GetMostPopularCourseAsync()
    {
        using var connection = _context.Connection();
        var query = @"SELECT c.CourseId, c.Title, COUNT(DISTINCT sg.StudentId) AS StudentCount
        FROM courses c
        JOIN groups g ON g.CourseId = c.CourseId
        JOIN studentgroups sg ON sg.GroupId = g.GroupId
        GROUP BY c.CourseId, c.Title
        HAVING COUNT(DISTINCT sg.StudentId) = (
            SELECT MAX(cnt) FROM (
                SELECT COUNT(DISTINCT sg2.StudentId) AS cnt
                FROM groups g2
                JOIN studentgroups sg2 ON sg2.GroupId = g2.GroupId
                GROUP BY g2.CourseId
            ) t
        )";
        var list = await connection.QueryAsync<CourseStudentCount>(query);
        return list.ToList();
    }

    public async Task<List<CourseStudentCount>> GetStudentsPerCourseAsync()
    {
        using var connection = _context.Connection();
        var query = @"SELECT c.CourseId, c.Title, COUNT(DISTINCT sg.StudentId) AS StudentCount
        FROM courses c
        LEFT JOIN groups g ON g.CourseId = c.CourseId
        LEFT JOIN studentgroups sg ON sg.GroupId = g.GroupId
        GROUP BY c.CourseId, c.Title
        ORDER BY c.CourseId";
        var list = await connection.QueryAsync<CourseStudentCount>(query);
        return list.ToList();
    }

    public async Task<List<CourseStudentCount>> GetTopThreeCoursesAsync()
    {
        using var connection = _context.Connection();
        var query = @"SELECT c.CourseId, c.Title, COUNT(DISTINCT sg.StudentId) AS StudentCount
        FROM courses c
        LEFT JOIN groups g ON g.CourseId = c.CourseId
        LEFT JOIN studentgroups sg ON sg.GroupId = g.GroupId
        GROUP BY c.CourseId, c.Title
        ORDER BY StudentCount DESC, c.CourseId
        LIMIT 3";
        var list = await connection.QueryAsync<CourseStudentCount>(query);
        return list.ToList();
    }


    public async Task<bool> UpdateCourseAsync(Course course)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"update courses set Title=@Title, 
        Description=@Description, 
        DurationWeeks = @DurationWeeks
        where CourseId = @CourseId";
        int rowsChanged = await connection.ExecuteAsync(query, course);
        return rowsChanged > 0;
    }
}
