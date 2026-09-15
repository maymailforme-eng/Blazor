using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models;

public partial class Student
{
    [Key]
    [Column("stud_id")]
    public int StudId { get; set; }

    [Column("last_name")]
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [Column("first_name")]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Column("middle_name")]
    [StringLength(50)]
    public string? MiddleName { get; set; }

    [Column("birth_date")]
    public DateOnly BirthDate { get; set; }

    [Column("email")]
    [StringLength(50)]
    public string? Email { get; set; }

    [Column("phone")]
    [StringLength(16)]
    public string? Phone { get; set; }

    [Column("photo", TypeName = "image")]
    public byte[]? Photo { get; set; }

    [Column("group")]
    public int? Group { get; set; }

    [InverseProperty("StudentNavigation")]
    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    [InverseProperty("StudentNavigation")]
    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    [InverseProperty("StudentNavigation")]
    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    [ForeignKey("Group")]
    [InverseProperty("Students")]
    public virtual Group? GroupNavigation { get; set; }
}
