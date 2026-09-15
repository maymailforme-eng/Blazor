using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models;

public partial class Holiday
{
    [Key]
    [Column("holiday_id")]
    public byte HolidayId { get; set; }

    [Column("holiday_name")]
    [StringLength(50)]
    public string HolidayName { get; set; } = null!;

    [Column("month")]
    public byte? Month { get; set; }

    [Column("day")]
    public byte? Day { get; set; }

    [Column("duration")]
    public byte Duration { get; set; }

    [InverseProperty("HolidayNavigation")]
    public virtual ICollection<DayOff> DayOffs { get; set; } = new List<DayOff>();
}
