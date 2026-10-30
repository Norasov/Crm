using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class AnalyticsRepository(AppDbContext context) : IAnalyticsRepository
{
    private readonly AppDbContext _context = context;
    public async Task<CompletionRate> GetComplationRateAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select
            count(*) as TotalCount,
            count(*) filter (where Status = 'Завершил') as FinishedCount,
            coalesce(round(100.0 * count(*) filter (where Status = 'Завершил') / nullif(count(*), 0), 2), 0) as Percent
        from studentgroups";
        return await connection.QueryFirstAsync<CompletionRate>(query);
    }

}
