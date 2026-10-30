namespace Domain.Interfaces;

public interface IStatisticsRepository
{
    Task<int> GetTotalStudentsCountAsync();
    Task<int> GetTotalGroupsCountAsync();
    Task<int> GetTotalCoursesCountAsync();
    Task<int> GetTotalMentorsCountAsync();
    Task<List<DateOnly>> GetAllStartDatesAsync();
}
