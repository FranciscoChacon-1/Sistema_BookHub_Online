using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_BookHub_Online.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Sistema_BookHub_Online.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly libreriaContext _context;
        public HomeController(libreriaContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(string searchQuery)
        {
            var userName = User.Identity.IsAuthenticated ? User.FindFirst(ClaimTypes.Name)?.Value : "Usuario";


            var listaIndex = (from l in _context.libros
                              join pr in _context.prestamos on l.id_Libros equals pr.id_libro
                              join su in _context.sucursales on pr.id_sucursal equals su.idsucursales
                              select new
                              {
                                  IdLibros = l.id_Libros,
                                  Titulo = l.Titulo,
                                  Ejemplares = l.ejemplares,
                                  Genero = l.Genero,
                                  NombreSucursal = su.Nombre
                              });

            if (!string.IsNullOrEmpty(searchQuery))
            {
                listaIndex = listaIndex.Where(l => l.Titulo.Contains(searchQuery));
            }

            ViewData["listaIndex"] = listaIndex.ToList();
            ViewBag.UserName = userName; // Pasa el nombre del usuario a la vista

            return View();
        }

        public IActionResult IndexAdmin()
        {
            return View("HomeAdmin");
        }

        public IActionResult IndexEmpleado()
        {
            return View("HomeEmpleado");
        }

        public IActionResult GotoEmpleados()
        {
            return RedirectToAction("Index", "Empleados");
        }
        public IActionResult Gotolibros()
        {
            return RedirectToAction("Index", "libros");
        } 
        public IActionResult Gotopedidos()
        {
            return RedirectToAction("Index", "pedidos");
        }
        public IActionResult GotoPrestamos()
        {
            return RedirectToAction("Index", "prestamos");
        }
        public IActionResult GotoSucursales()
        {
            return RedirectToAction("Index", "sucursales");
        }
        public IActionResult GotoUsuarios()
        {
            return RedirectToAction("Index", "usuarios");
        }

        public IActionResult GotoPrestamosCrear()
        {
            return RedirectToAction("Create", "prestamos");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
