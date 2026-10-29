using Domain.Models;

namespace Domain.Interfaces;

public interface ICourseRepository
{
    bool AddCourse(Course course);
    bool DeleteCourse(int courseId);
    bool UpdateCourse(Course course);
    Course GetCourse(int courseId);
    List<Course> GetCourses();
    List<CourseStudentCount> GetStudentsPerCourse();
    List<CourseStudentCount> GetMostPopularCourse();
    List<CourseStudentCount> GetLeastPopularCourses();
    List<CourseStudentCount> GetTopThreeCourses();
}
