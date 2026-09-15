using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models;

public partial class Discipline
{
    [Key]
    [Column("discipline_id")]
    public short DisciplineId { get; set; }

    [Column("discipline_name")]
    [StringLength(150)]
    public string? DisciplineName { get; set; }

    [Column("number_of_lessons")]
    public byte NumberOfLessons { get; set; }

    [InverseProperty("DisciplineNavigation")]
    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    [InverseProperty("DisciplineNavigation")]
    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    [ForeignKey("Discipline")]
    [InverseProperty("Disciplines")]
    public virtual ICollection<Discipline> DependentDiscipline1s { get; set; } = new List<Discipline>();

    [ForeignKey("Discipline")]
    [InverseProperty("Disciplines")]
    public virtual ICollection<Direction> Directions { get; set; } = new List<Direction>();

    [ForeignKey("DependentDiscipline1")]
    [InverseProperty("DependentDiscipline1s")]
    public virtual ICollection<Discipline> Disciplines { get; set; } = new List<Discipline>();

    [ForeignKey("RequiredDiscipline1")]
    [InverseProperty("RequiredDiscipline1s")]
    public virtual ICollection<Discipline> DisciplinesNavigation { get; set; } = new List<Discipline>();

    [ForeignKey("Discipline")]
    [InverseProperty("Disciplines")]
    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    [ForeignKey("Discipline")]
    [InverseProperty("DisciplinesNavigation")]
    public virtual ICollection<Discipline> RequiredDiscipline1s { get; set; } = new List<Discipline>();

    [ForeignKey("Discipline")]
    [InverseProperty("Disciplines")]
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
