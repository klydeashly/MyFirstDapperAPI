using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstDapperAPI.Model
{
    [Table("tbl_Student")]
    public class StudentModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("FirstName")]
        public string FirstName { get; set; }
        [Column("LastName")]
        public string LastName { get; set; }

    }
}
