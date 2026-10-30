using Domain.Models;

namespace Application.Interfaces;

public interface IMentorService
{
    Task AddMentorAsync(Mentor mentor);
    Task UpdateMentorAsync(Mentor mentor);
    Task DeleteMentorAsync(int mentorId);
    Task GetMentorAsync(int mentorId);
    Task GetAllMentorsAsync();
    Task GetMentorWithMostStudentsAsync();
    Task GetMentorsWithMultipleCoursesAsync();
}
