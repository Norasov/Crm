using Domain.Models;

namespace Application.Interfaces;

public interface ICourseService
{
    Task AddCourseAsync(Course course);
    Task UpdateCourseAsync(Course course);
    Task DeleteCourseAsync(int courseId);
    Task GetCourseAsync(int courseId);
    Task GetAllCoursesAsync();
}
