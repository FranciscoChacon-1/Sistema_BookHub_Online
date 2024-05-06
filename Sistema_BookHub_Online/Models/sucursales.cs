using System.ComponentModel.DataAnnotations;

namespace Sistema_BookHub_Online.Models
{
    public class sucursales
    {
        [Key]
        public int idsucursales { get; set; }
        public string? Nombre { get; set; }
        public string? Contacto { get; set; }
        public string? Direccion { get;}


    }
}
