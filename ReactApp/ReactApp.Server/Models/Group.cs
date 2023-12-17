using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Server.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению!")]
        [Column(TypeName = "nvarchar(10)")]
        [Range(2, 1000, ErrorMessage = "Минимальное количество символов - 2, максимальное - 10")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [Column(TypeName = "nvarchar(3)")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        public DateTime StartOfTraining { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        public DateTime EndOfTraining { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
