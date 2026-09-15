using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models;

[PrimaryKey("Student", "Discipline")]
public partial class Exam
{
    [Key]
    [Column("student")]
    public int Student { get; set; }

    [Key]
    [Column("discipline")]
    public short Discipline { get; set; }

    [Column("date")]
    public DateOnly? Date { get; set; }

    [Column("grade")]
    public byte? Grade { get; set; }

    [ForeignKey("Discipline")]
    [InverseProperty("Exams")]
    public virtual Discipline DisciplineNavigation { get; set; } = null!;

    [ForeignKey("Student")]
    [InverseProperty("Exams")]
    public virtual Student StudentNavigation { get; set; } = null!;
}
