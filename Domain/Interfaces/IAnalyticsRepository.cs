using Domain.Models;

namespace Domain.Interfaces;

public interface IAnalyticsRepository
{
    Task<CompletionRate> GetComplationRateAsync();
}
