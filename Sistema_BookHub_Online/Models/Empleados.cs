using Microsoft.Data.SqlClient.DataClassification;
using System.ComponentModel.DataAnnotations;

namespace Sistema_BookHub_Online.Models
{
    public class Empleados
    {
        [Key]
        public int id_Empleados { get; set; }
        public string? Nombre { get; set; }
        public string? Contacto { get; set; }
        public string? Correo { get; set; }
        public string? Encargo { get; set; }
        public int id_sucursal { get; set; }


    }
}
