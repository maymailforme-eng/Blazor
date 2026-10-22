namespace Academy.Models;

public class Direction
{
    public byte DirectionId { get; set; }
    public string DirectionName { get; set; } = null!;

    public ICollection<Group> Groups { get; set; } = new List<Group>();
}
