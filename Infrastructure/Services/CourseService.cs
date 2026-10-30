using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class CourseService(CourseRepository repository) : ICourseService
{
    private readonly CourseRepository _repository = repository;
    public async Task AddCourseAsync(Course course)
    {
        var addCourse = await _repository.AddCourseAsync(course);
        if (addCourse) System.Console.WriteLine("Added successfuly!");
        else System.Console.WriteLine("Something went wrong!");
    }

    public async Task DeleteCourseAsync(int courseId)
    {
        var deleteCourse = await _repository.DeleteCourseAsync(courseId);
        if (deleteCourse) System.Console.WriteLine("deleted successfuly!");
        else System.Console.WriteLine("Something went wrong!");
    }

    public async Task GetAllCoursesAsync()
    {
        var getCourses = await _repository.GetCoursesAsync();
        foreach (var item in getCourses)
        {
            System.Console.WriteLine(item.CourseId + " | " + item.Title + " | " + item.Description + " | " + item.DurationWeeks);
        }
    }

    public async Task GetCourseAsync(int courseId)
    {
        var getCourse = await _repository.GetCourseAsync(courseId);
        if(getCourse is null) System.Console.WriteLine("Курс не найден!");
        else System.Console.WriteLine(getCourse.CourseId + " | " + getCourse.Title + " | " + getCourse.Description + " | " + getCourse.DurationWeeks);
    }

    public async Task UpdateCourseAsync(Course course)
    {
        var updateCourse = await _repository.UpdateCourseAsync(course);
        System.Console.WriteLine(updateCourse ? "Updated successfuly!" : "Something went wrong!");
    }
}
