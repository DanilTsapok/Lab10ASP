using System.ComponentModel.DataAnnotations;

namespace Lab10.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage="Вкажіть еmail")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Мінімальнка кількість символів 3")]
        public string Email { get; set; }
        [Required]
        [StringLength(50, MinimumLength =8, ErrorMessage ="Мінімальна кількість символів для пароля 8")]
        public string Password { get; set; }

    }
}
