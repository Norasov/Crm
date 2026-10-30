using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;


namespace Infrastructure.Services;

public class StudentService(StudentRepository studentRepository) : IStudentService
{
    private readonly StudentRepository _repository = studentRepository;
    public async Task AddStudentAsync(Student student)
    {
        var addStudent = await _repository.AddStudentAsync(student);
        if (addStudent) System.Console.WriteLine("Added Successfuly!");
        else System.Console.WriteLine("Something went wrong!");
    }

    public async Task DeleteStudentAsync(int studentId)
    {
        var deleteStudent = await _repository.DeleteStudentAsync(studentId);
        if (deleteStudent) System.Console.WriteLine("Deleted successfuly!");
        else System.Console.WriteLine("Something went wrong");
    }

    public async Task GetAllStudentsAsync()
    {
        var getStudents = await _repository.GetStudentsAsync();
        foreach (var item in getStudents)
        {
            System.Console.WriteLine(item.StudentId + " | " + item.FullName + " | " + item.Email + " | " + item.Phone + " | " + item.EnrollmentDate);
        }
    }

    public async Task GetDroppedOutStudentsAsync()
    {
        var students = await _repository.GetDroppedOutStudentsAsync();
        if (students.Count == 0)
        {
            Console.WriteLine("Отчисленных студентов нет.");
            return;
        }

        foreach (var student in students)
        {
            Console.WriteLine($"{student.StudentId} | {student.FullName} | {student.Email} | {student.Phone}");
        }
    }

    public async Task GetGraduatedStudentsAsync()
    {
        var students = await _repository.GetGraduatedStudentsAsync();
        if (students.Count == 0)
        {
            Console.WriteLine("Завершивших курс студентов нет.");
            return;
        }

        foreach (var student in students)
        {
            Console.WriteLine($"{student.StudentId} | {student.FullName} | {student.Email} | {student.Phone}");
        }

    }

    public async Task GetStudentAsync(int studentId)
    {
        var getStudent = await _repository.GetStudentAsync(studentId);
        if(getStudent is null) System.Console.WriteLine("Студент не найден!");
        else System.Console.WriteLine(getStudent.StudentId + " | " + getStudent.FullName + " | " + getStudent.Email + " | " + getStudent.Phone + " | " + getStudent.EnrollmentDate);
    }

    public async Task GetStudentsWithGroupsAsync()
    {
        var studentWithGroups = await _repository.GetStudentsWithGroupsAsync();
        if (studentWithGroups.Count == 0)
        {
            Console.WriteLine("Данных нет.");
            return;
        }

        foreach (var s in studentWithGroups)
            Console.WriteLine($"{s.StudentId} | {s.FullName} | {s.GroupName} | {s.Status}");

    }

    public async Task GetStudentsWithoutGroupsAsync()
    {
        var students = await _repository.GetStudentsWithoutGroupsAsync();
        if (students.Count == 0)
        {
            Console.WriteLine("Все студенты записаны в группы.");
            return;
        }

        foreach (var student in students)
        {
            Console.WriteLine($"{student.StudentId} | {student.FullName} | {student.Email} | {student.Phone}");
        }
    }


    public async Task UpdateStudentAsync(Student student)
    {
        var updateStudent = await _repository.UpdateStudentAsync(student);
        if (updateStudent) System.Console.WriteLine("Updated successfuly!");
        else System.Console.WriteLine("Something went wrong!");
    }

}
