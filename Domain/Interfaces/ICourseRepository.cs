using Domain.Models;

namespace Domain.Interfaces;

public interface ICourseRepository
{
    Task<bool> AddCourseAsync(Course course);
    Task<bool> DeleteCourseAsync(int courseId);
    Task<bool> UpdateCourseAsync(Course course);
    Task<Course?> GetCourseAsync(int courseId);
    Task<List<Course>> GetCoursesAsync();
    Task<List<CourseStudentCount>> GetStudentsPerCourseAsync();
    Task<List<CourseStudentCount>> GetMostPopularCourseAsync();
    Task<List<CourseStudentCount>> GetLeastPopularCoursesAsync();
    Task<List<CourseStudentCount>> GetTopThreeCoursesAsync();
}
