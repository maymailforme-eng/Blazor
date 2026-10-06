using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class Discipline
    {
        [Key]
        [Column("discipline_id", TypeName = "SMALLINT")]
        public int discipline_id { get; set; }

        [Required]
        [StringLength(150)]
        public string discipline_name { get; set; }

        [Required]
        [Column(TypeName="TINYINT")]
        public int number_of_lessons { get; set; }


        //Navigation Properties
        public ICollection<TeachersDisciplinesRelation> TDR { get; set; } = [];

    }
}
