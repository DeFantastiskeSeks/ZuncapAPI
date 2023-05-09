using System.Reflection.PortableExecutable;

namespace ZuncapAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? Name { get; set; } 
        public int TelefonNummer { get; set; }
        public string? Password { get; set; }
        public int Hudtype { get; set; }
    }
}
