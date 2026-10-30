using Application.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class StatisticsService(StatisticsRepository repository):IStatisticsService
{
    private readonly StatisticsRepository _repository = repository;

    public async Task GetAllStartDatesAsync()
    {
        var dates = await _repository.GetAllStartDatesAsync();
        foreach (var item in dates)
        {
            System.Console.WriteLine(item);
        }
    }

    public async Task GetTotalCoursesCountAsync()
    {
        var totalCourses = await _repository.GetTotalCoursesCountAsync();
        System.Console.WriteLine($"Общее количество курсов: {totalCourses}");
    }

    public async Task GetTotalGroupsCountAsync()
    {
        var totalGroups = await _repository.GetTotalGroupsCountAsync();
        System.Console.WriteLine($"Общее количество групп: {totalGroups}");
    }

    public async Task GetTotalMentorsCountAsync()
    {
        var totalMentors = await _repository.GetTotalMentorsCountAsync();
        System.Console.WriteLine($"Общее количество менторов: {totalMentors}");
    }

    public async Task GetTotalStudentsCountAsync()
    {
        var totalStudents = await _repository.GetTotalStudentsCountAsync();
        System.Console.WriteLine($"Общее количество студентов: {totalStudents}");
    }
}
