using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models;

public partial class Group
{
    [Key]
    [Column("group_id")]
    public int GroupId { get; set; }

    [Column("group_name")]
    [StringLength(10)]
    public string GroupName { get; set; } = null!;

    [Column("direction")]
    public byte Direction { get; set; }

    [Column("start_date")]
    public DateOnly? StartDate { get; set; }

    [Column("start_time")]
    [Precision(0)]
    public TimeOnly? StartTime { get; set; }

    [Column("learning_days")]
    public byte? LearningDays { get; set; }

    [ForeignKey("Direction")]
    [InverseProperty("Groups")]
    public virtual Direction DirectionNavigation { get; set; } = null!;

    [InverseProperty("GroupNavigation")]
    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    [InverseProperty("GroupNavigation")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [ForeignKey("Group")]
    [InverseProperty("Groups")]
    public virtual ICollection<Discipline> Disciplines { get; set; } = new List<Discipline>();
}
