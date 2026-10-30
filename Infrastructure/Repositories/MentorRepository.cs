using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class MentorRepository(AppDbContext context) : IMentorRepository
{
    private readonly AppDbContext _context = context;
    public async Task<bool> AddMentorAsync(Mentor mentor)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"insert into mentors(FullName, Email, Phone, Specialization) values
        (@FullName, @Email, @Phone, @Specialization)";
        int rowsAdded = await connection.ExecuteAsync(query, mentor);
        return rowsAdded > 0;
    }

    public async Task<bool> DeleteMentorAsync(int mentorId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from mentors where MentorId = @MentorId";
        int rowsChanged = await connection.ExecuteAsync(query, new { mentorId });
        return rowsChanged > 0;
    }

    public async Task<Mentor?> GetMentorAsync(int mentorId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from mentors where MentorId = @MentorId";
        return await connection.QueryFirstOrDefaultAsync<Mentor>(query, new { mentorId });
    }

    public async Task<List<Mentor>> GetMentorsAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from mentors";
        var list = await connection.QueryAsync<Mentor>(query);
        return list.ToList();
    }

    public async Task<List<MentorCourseCount>> GetMentorsWithMultipleCoursesAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"SELECT m.MentorId, m.FullName, COUNT(DISTINCT g.CourseId) AS CourseCount
        FROM mentors m
        JOIN groups g ON g.MentorId = m.MentorId
        GROUP BY m.MentorId, m.FullName
        HAVING COUNT(DISTINCT g.CourseId) > 1
        ORDER BY CourseCount DESC";
        var list = await connection.QueryAsync<MentorCourseCount>(query);
        return list.ToList();
    }

    public async Task<List<MentorStudentCount>> GetMentorWithMostStudentsAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select m.MentorId, m.FullName, count(distinct sg.StudentId) as StudentCount
        from mentors m
        join groups g on g.MentorId = m.MentorId
        join studentgroups sg on sg.GroupId = g.GroupId
        group by m.MentorId, m.FullName
        HAVING COUNT(DISTINCT sg.StudentId) = (
            SELECT MAX(cnt) FROM (
                SELECT COUNT(DISTINCT sg2.StudentId) AS cnt
                FROM groups g2
                JOIN studentgroups sg2 ON sg2.GroupId = g2.GroupId
                GROUP BY g2.MentorId
                    ) t
                )";
        var list = await connection.QueryAsync<MentorStudentCount>(query);
        return list.ToList();
    }


    public async Task<bool> UpdateMentorAsync(Mentor mentor)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"update mentors set FullName = @FullName, Email=@Email,
        Phone=@Phone, Specialization=@Specialization
        where MentorId = @MentorId";
        int rowsChanged = await connection.ExecuteAsync(query, mentor);
        return rowsChanged > 0;
    }
}
