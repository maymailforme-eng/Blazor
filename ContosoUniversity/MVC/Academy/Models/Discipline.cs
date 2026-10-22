namespace Academy.Models;

public class Discipline
{
    public short DisciplineId { get; set; }
    public string DisciplineName { get; set; } = null!;
    public byte NumberOfLessons { get; set; }
}
