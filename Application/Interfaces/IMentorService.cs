using Domain.Models;

namespace Application.Interfaces;

public interface IMentorService
{
    void AddMentor(Mentor mentor);
    void UpdateMentor(Mentor mentor);
    void DeleteMentor(int mentorId);
    void GetMentor(int mentorId);
    void GetAllMentors();
    void GetMentorWithMostStudents();
    void GetMentorsWithMultipleCourses();
}
