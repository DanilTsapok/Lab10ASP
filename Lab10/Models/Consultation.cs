using Lab10.Models.Validators;
using System.ComponentModel.DataAnnotations;

namespace Lab10.Models
{
    public class Consultation
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Вкажіть ім'я")]
        [StringLength(100, MinimumLength = 2, ErrorMessage ="Мінімальна кількість символів 2")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Вкажіть Прізвище")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Мінімальна кількість символів 2")]
        public string Surname { get; set; }


        [Required(ErrorMessage ="Вкажіть пошту")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некоректна адреса")]
        [EmailAddress(ErrorMessage ="Не правильний формат пошти")]
        public string Email {  get; set; }


        [Required(ErrorMessage = "Вкажіть дату консультації")]
        [DataType(DataType.Date)]
        [WeekendAttribute(ErrorMessage = "Дата не має попадати на вихідні дні")]
        [FutureAttribute(ErrorMessage ="Дата має бути майбутня")]
        [Display(Name = "Дата консультації")]
        public DateTime DateConsultation { get; set; }

        [Required(ErrorMessage ="Вкажіть предмет")]
        public string Subject {  get; set; }

    }
}
