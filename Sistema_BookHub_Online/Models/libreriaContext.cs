using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;


namespace Sistema_BookHub_Online.Models
{
    public class libreriaContext : DbContext
    {
        public libreriaContext(DbContextOptions options)  : base(options)
        {
          
        }
         public DbSet<Editoriales>Editoriales { get; set; }
         public DbSet<Empleados> Empleados { get; set;}
        public DbSet<libros> libros { get; set; }
        public DbSet<pedidos> pedidos { get; set;}
        public DbSet<prestamos> prestamos { get; set;}
        public DbSet<sucursales> sucursales { get; set; }
        public DbSet<usuarios> usuarios { get; set; }

        
    }
}
