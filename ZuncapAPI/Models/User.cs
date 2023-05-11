using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;

namespace ZuncapAPI.Models
{
    public class User
    {
 
        public int UserId { get; set; }
        [Required(ErrorMessage = "Brugernavn kræves")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Telefon nummer kræves")]
        public int TelefonNummer { get; set; }
        public string? Password { get; set; }
        public int Hudtype { get; set; }
    }
}
