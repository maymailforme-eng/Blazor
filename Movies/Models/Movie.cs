using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        //[StringLength(50, MinimumLength=2)]
        //[MinLength(2), MaxLength(50)]
        [MinLength(2, ErrorMessage = "Слишком мало"), MaxLength(50, ErrorMessage = "Слишком много")]
        [Display(Name = "Название")]
        public string Title { get; set; }


        //[RangeAttribute(typeof(DateOnly), "1888-10-14", "2128-12-31")]
        [RangeAttribute(typeof(DateOnly), "1888-10-14", "2128-12-31", ErrorMessage = "Тогда кино либо еще не снимали, либо уже ничего не снимут")]
        [Display(Name = "Дата выхода")]
        public DateOnly ReleaseDate { get; set; }


        [DisplayName("Жанр")]
        public string? Gener {  get; set; }
        public string? URL { get; set; }
        public string Psoter { get; set; }
    }
}
