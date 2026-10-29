using Domain.Models;

namespace Application.Interfaces;

public interface ICourseService
{
    void AddCourse(Course course);
    void UpdateCourse(Course course);
    void DeleteCourse(int courseId);
    void GetCourse(int courseId);
    void GetAllCourses();
}
