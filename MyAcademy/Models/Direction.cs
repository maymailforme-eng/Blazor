using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAcademy.Models;

public partial class Direction
{
    [Key]
    [Column("direction_id")]
    public byte DirectionId { get; set; }

    [Column("direction_name")]
    [StringLength(50)]
    public string? DirectionName { get; set; }

    [InverseProperty("DirectionNavigation")]
    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    [ForeignKey("Direction")]
    [InverseProperty("Directions")]
    public virtual ICollection<Discipline> Disciplines { get; set; } = new List<Discipline>();
}
