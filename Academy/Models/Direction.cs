using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class Direction
    {
        [Key] //отметка о первичном ключе
        [Column(TypeName ="TINYINT")]
        public int direction_id { get; set; }
        public string direction_name { get; set; }
    }
}
