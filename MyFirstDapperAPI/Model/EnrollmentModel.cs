using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstDapperAPI.Model
{
    [Table("tbl_Enrollment")]
    public class EnrollmentModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("StudentId")]
        public int StudentId { get; set; }
        [Column("CourseId")]
        public int CourseId { get; set; }
    }
}
