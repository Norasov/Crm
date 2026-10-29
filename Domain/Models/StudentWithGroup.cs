namespace Domain.Models;

public class StudentWithGroup
{
    public int StudentId { get; set; }
    public string FullName { get; set; } = null!;
    public int GroupId { get; set; }
    public string GroupName { get; set; } = null!;
    public string Status { get; set; } = null!;
}
