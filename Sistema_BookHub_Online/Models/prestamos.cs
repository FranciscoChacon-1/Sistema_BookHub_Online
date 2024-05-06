using System.ComponentModel.DataAnnotations;

namespace Sistema_BookHub_Online.Models
{
    public class prestamos
    {
        [Key]
        public int id_libro { get; set; }
        public int id_usuario { get; set; }
        public DateTime Fecha_prestamo { get; set; }
        public string? Estado { get; set; }
        public int id_sucursal { get; set;}

    }
}
