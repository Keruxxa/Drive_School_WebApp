using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Server.Models
{
    public class PracticalExam
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению!")]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
