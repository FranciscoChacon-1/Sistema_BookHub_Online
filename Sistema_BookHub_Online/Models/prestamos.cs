using System.ComponentModel.DataAnnotations;

namespace Sistema_BookHub_Online.Models
{
    public class prestamos
    {
        [Key]
        public int id_libro { get; set; }
        public int id_usuario { get; set; }
        public DateTime Fecha_prestamo { get; set; } = DateTime.Now;
        public string? Estado { get; set; } = "SI";
        public int id_sucursal { get; set;}

    }
}
