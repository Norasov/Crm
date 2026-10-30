using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class MentorService(MentorRepository repository) : IMentorService
{
    private readonly MentorRepository _repository = repository;

    public async Task AddMentorAsync(Mentor mentor)
    {
        var addMentor = await _repository.AddMentorAsync(mentor);
        System.Console.WriteLine(addMentor ? "Added succesfuly!" : "Something went wrong!");

    }

    public async Task DeleteMentorAsync(int mentorId)
    {
        var deleteMentor = await _repository.DeleteMentorAsync(mentorId);
        System.Console.WriteLine(deleteMentor ? "Deleted Successfuly!" : "Something went wrong");
    }

    public async Task GetAllMentorsAsync()
    {
        var getMentors = await _repository.GetMentorsAsync();
        foreach (var item in getMentors)
        {
            System.Console.WriteLine(item.MentorId + " | " + item.FullName + " | " + item.Phone + " | " + item.Specialization + " | " + item.Email);
        }
    }

    public async Task GetMentorAsync(int mentorId)
    {
        var getMentor = await _repository.GetMentorAsync(mentorId);
        if(getMentor is null) System.Console.WriteLine("Ментор не найден!");
        else System.Console.WriteLine(getMentor.MentorId + " | " + getMentor.FullName + " | " + getMentor.Phone + " | " + getMentor.Specialization + " | " + getMentor.Email);
    }

    public async Task GetMentorsWithMultipleCoursesAsync()
    {
        var mentors = await _repository.GetMentorsWithMultipleCoursesAsync();
        if (mentors.Count == 0)
        {
            System.Console.WriteLine("Наставников с несколькими курсами нет.");
            return;
        }
        foreach (var mentor in mentors)
        {
            System.Console.WriteLine(mentor.MentorId + " | " + mentor.FullName + " | " + mentor.CourseCount);
        }
    }

    public async Task GetMentorWithMostStudentsAsync()
    {
        var mentors = await _repository.GetMentorWithMostStudentsAsync();
        if (mentors.Count == 0)
        {
            Console.WriteLine("Данных нет.");
            return;
        }
        foreach (var mentor in mentors)
        {
            System.Console.WriteLine(mentor.MentorId + " | " + mentor.FullName + " | Студентов: " + mentor.StudentCount);

        }
    }


    public async Task UpdateMentorAsync(Mentor mentor)
    {
        var updateMentor = await _repository.UpdateMentorAsync(mentor);
        System.Console.WriteLine(updateMentor ? "Updated successfuly!" : "Something went wrong!");
    }
}
