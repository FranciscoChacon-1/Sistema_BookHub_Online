using System.ComponentModel.DataAnnotations;

namespace Sistema_BookHub_Online.Models
{
    public class pedidos
    {
        [Key]
        public int id_Pedido { get; set; }
        public DateTime Fecha_pedido { get; set; }
        public int Cantidad { get; set; }
        public string? Titulo_libro { get; set; }
        public int id_editorial { get; set; }
        public int id_empleado { get; set; }
        public int id_sucursal { get; set; }

    }
}
