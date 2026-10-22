using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength =2)]
        [DisplayName("Имя")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [DisplayName("Фамилия")]
        public string FirstName { get; set; }

        [DisplayName("Дата поступления")]
        [DisplayFormat(DataFormatString ="{0:yyyy.MM.dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }


        //calculated properties
        public string FullName
        {
            get => $"{LastName} {FirstName}";
        }

        //Navigation properties:
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
