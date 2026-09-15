using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models;

[PrimaryKey("Student", "Lesson")]
public partial class Grade
{
    [Key]
    [Column("student")]
    public int Student { get; set; }

    [Key]
    [Column("lesson")]
    public long Lesson { get; set; }

    [Column("grade_1")]
    public byte? Grade1 { get; set; }

    [Column("grade_2")]
    public byte? Grade2 { get; set; }

    [ForeignKey("Lesson")]
    [InverseProperty("Grades")]
    public virtual Schedule LessonNavigation { get; set; } = null!;

    [ForeignKey("Student")]
    [InverseProperty("Grades")]
    public virtual Student StudentNavigation { get; set; } = null!;
}
