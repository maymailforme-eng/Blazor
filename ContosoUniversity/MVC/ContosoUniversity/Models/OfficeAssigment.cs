using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace ContosoUniversity.Models
{
    public class OfficeAssigment
    {
        [Key]
        public int InstructorID { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        //Navigation properties:
        public Instructor Instructor { get; set; }
    }
}
