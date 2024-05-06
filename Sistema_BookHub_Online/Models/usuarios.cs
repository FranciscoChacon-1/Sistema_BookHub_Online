using System.ComponentModel.DataAnnotations;

namespace Sistema_BookHub_Online.Models
{
    public class usuarios
    {
        [Key]
        public int id_Usuario { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }

    }
}
