using Domain.Models;

namespace Domain.Interfaces;

public interface IMentorRepository
{
    bool AddMentor(Mentor mentor);
    bool DeleteMentor(int mentorId);
    bool UpdateMentor(Mentor mentor);
    Mentor GetMentor(int mentorId);
    List<Mentor> GetMentors();
    List<MentorStudentCount> GetMentorWithMostStudents();
    List<MentorCourseCount> GetMentorsWithMultipleCourses();
}
