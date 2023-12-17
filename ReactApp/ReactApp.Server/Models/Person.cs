using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Server.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Range(16, int.MaxValue, ErrorMessage = "Возраст обучающегося не может быть меньше 16 лет!")]
        public int? Age { get; set; }
    }
}
