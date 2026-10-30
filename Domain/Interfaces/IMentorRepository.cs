using Domain.Models;

namespace Domain.Interfaces;

public interface IMentorRepository
{
    Task<bool> AddMentorAsync(Mentor mentor);
    Task<bool> DeleteMentorAsync(int mentorId);
    Task<bool> UpdateMentorAsync(Mentor mentor);
    Task<Mentor?> GetMentorAsync(int mentorId);
    Task<List<Mentor>> GetMentorsAsync();
    Task<List<MentorStudentCount>> GetMentorWithMostStudentsAsync();
    Task<List<MentorCourseCount>> GetMentorsWithMultipleCoursesAsync();
}
