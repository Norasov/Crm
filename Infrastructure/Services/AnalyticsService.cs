using Application.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class AnalyticsService(AnalyticsRepository repository):IAnalyticsService
{
    private readonly AnalyticsRepository _repository = repository;

    public async Task GetCompletionRateAsync()
    {
        var rate = await _repository.GetComplationRateAsync();
        System.Console.WriteLine($"Finished: {rate.FinishedCount} | {rate.TotalCount} | {rate.Percent}%");
    }

}
