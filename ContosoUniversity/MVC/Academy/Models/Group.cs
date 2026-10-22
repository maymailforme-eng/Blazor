namespace Academy.Models;

public class Group
{
    public int GroupId { get; set; }
    public string GroupName { get; set; } = null!;
    public byte DirectionId { get; set; }
    public DateOnly? StartDate { get; set; }
    public TimeOnly? StartTime { get; set; }
    public byte? LearningDays { get; set; }

    public Direction Direction { get; set; } = null!;
    public ICollection<Student> Students { get; set; } = new List<Student>();
}
