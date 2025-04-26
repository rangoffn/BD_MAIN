using System.ComponentModel.DataAnnotations;

namespace BACKENDD.Models
{
    public class Contact
    {

        [Key] 
        public int Id { get; set; }  

        [Display(Name = "Введите Имя")]
        [Required(ErrorMessage = "ЗАПОЛНИТЕ!")]

        public required string Name { get; set; }

        [Display(Name = "Введите Фамилию")]
        [Required(ErrorMessage = "ЗАПОЛНИТЕ!")]


        public required string SecName { get; set; }

        [Display(Name = "Введите Возраст")]
        [Required(ErrorMessage = "ЗАПОЛНИТЕ!")]

        public required int Age { get; set; }

        [Display(Name = "Введите Почту")]
        [Required(ErrorMessage = "ЗАПОЛНИТЕ!")]

        public required string Email { get; set; }

        [Display(Name = "Введите Сообщение")]
        [Required(ErrorMessage = "ЗАПОЛНИТЕ!")]

        public required string Message { get; set; }





    }
}
