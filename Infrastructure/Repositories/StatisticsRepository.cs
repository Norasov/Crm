using Dapper;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class StatisticsRepository(AppDbContext context) : IStatisticsRepository
{
    private readonly AppDbContext _context = context;
    public async Task<List<DateOnly>> GetAllStartDatesAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select distinct StartDate from groups order by StartDate";
        var list = await connection.QueryAsync<DateOnly>(query);
        return list.ToList();
    }

    public async Task<int> GetTotalCoursesCountAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select count(distinct CourseId) from courses";
        return await connection.ExecuteScalarAsync<int>(query);
    }

    public async Task<int> GetTotalGroupsCountAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select count(distinct GroupId) from groups";
        return await connection.ExecuteScalarAsync<int>(query);
    }

    public async Task<int> GetTotalMentorsCountAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select count(*) from mentors";
        return await connection.ExecuteScalarAsync<int>(query);
    }

    public async Task<int> GetTotalStudentsCountAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select count(*) from students";
        return await connection.ExecuteScalarAsync<int>(query);
    }

}
