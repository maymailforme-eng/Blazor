using System.ComponentModel.DataAnnotations;

namespace Academy.Models
{
    public class Human
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression("^[A-ZА-Я][a-zа-я]*$", ErrorMessage = "Фамилия содержит недопустимый символ")]
        public string last_name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression("^[A-ZА-Я][a-zа-я]*$", ErrorMessage = "Имя содержит недопустимый символ")]
        public string first_name { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [RegularExpression("^[A-ZА-Я][a-zа-я]*$", ErrorMessage = "Отчество содержит недопустимый символ")]
        public string? middle_name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [RangeAttribute(typeof(DateOnly), "1950-01-01", "2020-01-01")]
        public DateOnly birth_date { get; set; }

        public string? email { get; set; }
        public string? phone { get; set; }
        public byte[]? photo { get; set; }

        //Calculated properties

        public string FullName
        { 
            get => $"{last_name} {first_name} {middle_name}"; 
        }

    }
}
