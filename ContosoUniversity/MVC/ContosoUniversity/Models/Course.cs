using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // эта анатция отключает автоинкремент
        public int CourseID { get; set; }

        public string Title { get; set; }

        [Range(0,5)]
        public int Credits { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentID { get; set; }

        //Navigation properties:
        public ICollection<Enrollment> Enrollments { get; set; }
        public Department Department { get; set; }
        public ICollection<CourseAssigment> CourseAssigments { get; set; }


    }
}
