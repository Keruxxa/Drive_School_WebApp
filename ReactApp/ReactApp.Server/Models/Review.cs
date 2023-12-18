using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Server.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению!")]
        [Column(TypeName = "nvarchar(1000)")]
        [Range(10, 1000, ErrorMessage = "Минимальное количество символов - 10, максимальное - 1000")]
        public string Text { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }
    }
}
