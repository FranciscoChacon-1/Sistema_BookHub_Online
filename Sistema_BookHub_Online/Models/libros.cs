using System.ComponentModel.DataAnnotations;

namespace Sistema_BookHub_Online.Models
{
    public class libros
    {
        [Key]
        public int id_Libros { get; set; }
        public string?  Titulo { get; set; }
        public string? Autor { get; set; }
        public DateTime año_publicacion { get; set; }
        public int ejemplares { get; set; }
        public string? Genero { get; set; }
        public int id_Editorial { get; set; }
    }
} 
