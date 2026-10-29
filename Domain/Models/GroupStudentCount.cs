namespace Domain.Models;

public class GroupStudentCount
{
    public int GroupId {get;set;}
    public string GroupName {get;set;}=null!;
    public int StudentCount{get;set;}
}
