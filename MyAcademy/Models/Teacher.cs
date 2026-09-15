using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models;

public partial class Teacher
{
    [Key]
    [Column("teacher_id")]
    public short TeacherId { get; set; }

    [Column("last_name")]
    [StringLength(50)]
    public string? LastName { get; set; }

    [Column("first_name")]
    [StringLength(50)]
    public string? FirstName { get; set; }

    [Column("middle_name")]
    [StringLength(50)]
    public string? MiddleName { get; set; }

    [Column("birth_date")]
    public DateOnly? BirthDate { get; set; }

    [Column("email")]
    [StringLength(50)]
    public string? Email { get; set; }

    [Column("phone")]
    [StringLength(16)]
    public string? Phone { get; set; }

    [Column("photo", TypeName = "image")]
    public byte[]? Photo { get; set; }

    [Column("work_since")]
    public DateOnly? WorkSince { get; set; }

    [Column("rate", TypeName = "smallmoney")]
    public decimal? Rate { get; set; }

    [InverseProperty("TeacherNavigation")]
    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    [ForeignKey("Teacher")]
    [InverseProperty("Teachers")]
    public virtual ICollection<Discipline> Disciplines { get; set; } = new List<Discipline>();
}
