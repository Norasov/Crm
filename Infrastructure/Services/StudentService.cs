using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repositories;


namespace Application.Services;

public class StudentService(StudentRepository studentRepository) : IStudentService
{
    private readonly StudentRepository _repository = studentRepository;
    public void AddStudent(Student student)
    {
        var addStudent = _repository.AddStudent(student);
        if (addStudent) System.Console.WriteLine("Added Successfuly!");
        else System.Console.WriteLine("Something went wrong!");
    }

    public void DeleteStudent(int studentId)
    {
        var deleteStudent = _repository.DeleteStudent(studentId);
        if (deleteStudent) System.Console.WriteLine("Deleted successfuly!");
        else System.Console.WriteLine("Something went wrong");
    }

    public void GetAllStudents()
    {
        var getStudents = _repository.GetStudents();
        foreach (var item in getStudents)
        {
            System.Console.WriteLine(item.StudentId + " | " + item.FullName + " | " + item.Email + " | " + item.Phone + " | " + item.EnrollmentDate);
        }
    }

    public void GetDroppedOutStudents()
    {
        var students = _repository.GetDroppedOutStudents();
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

    public void GetGraduatedStudents()
    {
        var students = _repository.GetGraduatedStudents();
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


    public void GetStudent(int studentId)
    {
        var getStudent = _repository.GetStudent(studentId);
        System.Console.WriteLine(getStudent.StudentId + " | " + getStudent.FullName + " | " + getStudent.Email + " | " + getStudent.Phone + " | " + getStudent.EnrollmentDate);

    }

    public void GetStudentsWithGroups()
    {
        var studentWithGroups = _repository.GetStudentsWithGroups();
        if (studentWithGroups.Count == 0)
        {
            Console.WriteLine("Данных нет.");
            return;
        }

        foreach (var s in studentWithGroups)
            Console.WriteLine($"{s.StudentId} | {s.FullName} | {s.GroupName} | {s.Status}");

    }

    public void GetStudentsWithoutGroups()
    {
        var students = _repository.GetStudentsWithoutGroups();
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


    public void UpdateStudent(Student student)
    {
        var updateStudent = _repository.UpdateStudent(student);
        if (updateStudent) System.Console.WriteLine("Updated successfuly!");
        else System.Console.WriteLine("Something went wrong!");
    }

}
