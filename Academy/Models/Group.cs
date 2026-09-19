using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class Group
    {
        [Key]
        public int group_id { get; set; }

        [Required] //обязательное поле - нельзя оставить пустым
        [StringLength(10, MinimumLength = 5)] //длины слов
        public string group_name { get; set; }

        [Required]
        [Column(TypeName = "TINYINT")]
        [ForeignKey(nameof(Direction))]
        public int direction { get; set; }

        public DateOnly? start_date { get; set; }
        public TimeOnly? start_time { get; set; }

        [Column(TypeName = "TINYINT")]
        public int? learning_days { get; set; }

        //navigation properties - раздел для связи таблиц

        public Direction Direction { get; set; } //экземпляр таблицы с которой будет связана наша таблиа 


    }
}
