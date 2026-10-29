using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class MentorService(MentorRepository repository) : IMentorService
{
    private readonly MentorRepository _repository = repository;

    public void AddMentor(Mentor mentor)
    {
        var addMentor = _repository.AddMentor(mentor);
        System.Console.WriteLine(addMentor ? "Added succesfuly!" : "Something went wrong!");

    }

    public void DeleteMentor(int mentorId)
    {
        var deleteMentor = _repository.DeleteMentor(mentorId);
        System.Console.WriteLine(deleteMentor ? "Deleted Successfuly!" : "Something went wrong");
    }

    public void GetAllMentors()
    {
        var getMentors = _repository.GetMentors();
        foreach (var item in getMentors)
        {
            System.Console.WriteLine(item.MentorId + " | " + item.FullName + " | " + item.Phone + " | " + item.Specialization + " | " + item.Email);
        }
    }

    public void GetMentor(int mentorId)
    {
        var getMentor = _repository.GetMentor(mentorId);
        System.Console.WriteLine(getMentor.MentorId + " | " + getMentor.FullName + " | " + getMentor.Phone + " | " + getMentor.Specialization + " | " + getMentor.Email);
    }

    public void GetMentorsWithMultipleCourses()
    {
        var mentors = _repository.GetMentorsWithMultipleCourses();
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

    public void GetMentorWithMostStudents()
    {
        var mentors = _repository.GetMentorWithMostStudents();
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


    public void UpdateMentor(Mentor mentor)
    {
        var updateMentor = _repository.UpdateMentor(mentor);
        System.Console.WriteLine(updateMentor ? "Updated successfuly!" : "Something went wrong!");
    }
}
