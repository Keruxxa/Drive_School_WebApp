using System.ComponentModel.DataAnnotations;

namespace API.Server.Models
{
    public class Teacher : Person
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [Range(5, int.MaxValue, ErrorMessage = "Необходимый минимум водительского стажа - 5 лет!")]
        public int Experience { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}
