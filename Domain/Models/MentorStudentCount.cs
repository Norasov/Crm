namespace Domain.Models;

public class MentorStudentCount
{
    public int MentorId {get;set;}
    public string FullName {get;set;}=null!;
    public int StudentCount {get;set;}
}
