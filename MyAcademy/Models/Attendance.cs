using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models;

[PrimaryKey("Student", "Lesson")]
[Table("Attendance")]
public partial class Attendance
{
    [Key]
    [Column("student")]
    public int Student { get; set; }

    [Key]
    [Column("lesson")]
    public long Lesson { get; set; }

    [Column("present")]
    public bool Present { get; set; }

    [ForeignKey("Lesson")]
    [InverseProperty("Attendances")]
    public virtual Schedule LessonNavigation { get; set; } = null!;

    [ForeignKey("Student")]
    [InverseProperty("Attendances")]
    public virtual Student StudentNavigation { get; set; } = null!;
}
