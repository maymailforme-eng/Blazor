using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Reflection.Metadata;

namespace Academy.Models
{
    public class Teacher : Human
    {
        [Key]
        [Column(TypeName = "SMALLINT")]
        public int teacher_id { get; set; }

        [Column(TypeName ="DATE")]
        public DateOnly work_since {  get; set; }

        [Column("rate", TypeName ="SMALLMONEY")]
        public decimal rate { get; set; }
    }
}
