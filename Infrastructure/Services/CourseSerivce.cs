using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class CourseSerivce(CourseRepository repository) : ICourseService
{
    private readonly CourseRepository _repository = repository;
    public void AddCourse(Course course)
    {
        var addCourse = _repository.AddCourse(course);
        if (addCourse) System.Console.WriteLine("Added successfuly!");
        else System.Console.WriteLine("Something went wrong!");
    }

    public void DeleteCourse(int courseId)
    {
        var deleteCourse = _repository.DeleteCourse(courseId);
        if (deleteCourse) System.Console.WriteLine("deleted successfuly!");
        else System.Console.WriteLine("Something went wrong!");
    }

    public void GetAllCourses()
    {
        var getCourses = _repository.GetCourses();
        foreach (var item in getCourses)
        {
            System.Console.WriteLine(item.CourseId + " | " + item.Title + " | " + item.Description + " | " + item.DurationWeeks);
        }
    }

    public void GetCourse(int courseId)
    {
        var getCourse = _repository.GetCourse(courseId);
        System.Console.WriteLine(getCourse.CourseId + " | " + getCourse.Title + " | " + getCourse.Description + " | " + getCourse.DurationWeeks);
    }

    public void UpdateCourse(Course course)
    {
        var updateCourse = _repository.UpdateCourse(course);
        System.Console.WriteLine(updateCourse ? "Updated successfuly!" : "Something went wrong!");
    }
}
