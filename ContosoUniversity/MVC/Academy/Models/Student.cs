using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Academy.Models;

public class Student
{
    public int StudentId { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    [DisplayName("Имя")]
    public string LastName { get; set; } = null!;

    [Required]
    [StringLength(50, MinimumLength = 2)]
    [DisplayName("Фамилия")]
    public string FirstName { get; set; } = null!;

    [StringLength(50, MinimumLength = 2)]
    [DisplayName("Фамилия")]
    public string? MiddleName { get; set; }

    [Required]
    [DisplayName("Дата рождения")]
    public DateOnly BirthDate { get; set; }

    public string? Email { get; set; }

    [DisplayName("Номер телефона")]
    public string? Phone { get; set; }

    [DisplayName("Фото")]
    public byte[]? Photo { get; set; }
    public int? GroupId { get; set; }

    public Group? Group { get; set; }
}
