using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models;

[PrimaryKey("Date", "Holiday")]
[Table("DayOFF")]
public partial class DayOff
{
    [Key]
    [Column("date")]
    public DateOnly Date { get; set; }

    [Key]
    [Column("holiday")]
    public byte Holiday { get; set; }

    [ForeignKey("Holiday")]
    [InverseProperty("DayOffs")]
    public virtual Holiday HolidayNavigation { get; set; } = null!;
}
