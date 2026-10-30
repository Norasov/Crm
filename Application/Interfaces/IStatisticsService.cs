namespace Application.Interfaces;

public interface IStatisticsService
{
    Task GetTotalStudentsCountAsync();
    Task GetTotalGroupsCountAsync();
    Task GetTotalCoursesCountAsync();
    Task GetTotalMentorsCountAsync();
    Task GetAllStartDatesAsync();
}
