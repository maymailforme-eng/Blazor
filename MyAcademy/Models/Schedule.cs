using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models;

[Table("Schedule")]
public partial class Schedule
{
    [Key]
    [Column("lesson_id")]
    public long LessonId { get; set; }

    [Column("group")]
    public int Group { get; set; }

    [Column("discipline")]
    public short Discipline { get; set; }

    [Column("teacher")]
    public short Teacher { get; set; }

    [Column("date")]
    public DateOnly? Date { get; set; }

    [Column("time")]
    [Precision(0)]
    public TimeOnly? Time { get; set; }

    [Column("spent")]
    public bool? Spent { get; set; }

    [InverseProperty("LessonNavigation")]
    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    [ForeignKey("Discipline")]
    [InverseProperty("Schedules")]
    public virtual Discipline DisciplineNavigation { get; set; } = null!;

    [InverseProperty("LessonNavigation")]
    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    [ForeignKey("Group")]
    [InverseProperty("Schedules")]
    public virtual Group GroupNavigation { get; set; } = null!;

    [ForeignKey("Teacher")]
    [InverseProperty("Schedules")]
    public virtual Teacher TeacherNavigation { get; set; } = null!;
}
