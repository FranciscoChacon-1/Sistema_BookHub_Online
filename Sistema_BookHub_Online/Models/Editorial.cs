using System.ComponentModel.DataAnnotations;

namespace Sistema_BookHub_Online.Models
{
    public class Editorial
    {
        [Key]
        public int id_Editorial { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Ubicacion { get; set; }
        public string? Contacto { get; set; }

    }
}
