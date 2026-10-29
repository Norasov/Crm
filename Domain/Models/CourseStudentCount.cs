namespace Domain.Models;

public class CourseStudentCount
{
    public int CourseId { get; set; }
    public string CourseName { get; set; } = null!;
    public int StudentCount { get; set; }

}
