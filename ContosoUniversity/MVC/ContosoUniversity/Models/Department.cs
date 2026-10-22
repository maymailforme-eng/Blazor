using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName ="MONEY")]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="0:yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        public int InstructorID { get; set; }

        //Navigation properties:

        public Instructor Administrator { get; set; }
        public ICollection<Course> Course { get; set; }


    }
}
