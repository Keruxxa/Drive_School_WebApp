using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Server.Models
{
   public class Car
   {
      [Key]
      public int Id { get; set; }

      [Required(ErrorMessage = "Поле обязательно к заполнению!")]
      [Column(TypeName = "nvarchar(50)")]
      public string Mark { get; set; }

      [Required(ErrorMessage = "Поле обязательно к заполнению!")]
      [Column(TypeName = "nvarchar(6)")]
      [StringLength(6, ErrorMessage = "Длина госномера состоит из 6 символов")]
      public string StateNumber { get; set; }

      public int? StudentId { get; set; }

      public Student? Student { get; set; }

      public int? TeacherId { get; set; }

      public Teacher? Teacher { get; set; }
   }
}
