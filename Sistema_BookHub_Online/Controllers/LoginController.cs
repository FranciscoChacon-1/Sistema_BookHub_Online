using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_BookHub_Online.Models;
using System.Text.Json;

namespace Sistema_BookHub_Online.Controllers
{
    public class LoginController : Controller
    {
        private readonly libreriaContext _context;

        public LoginController(libreriaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ValidarUsuario(credenciales credenciales)
        {
            //Se busca en ambas tablas para determinar a que grupo pertenecen las credenciales
            usuarios? usuario = (from user in _context.usuarios
                                 where user.Correo == credenciales.correo
                                 && user.id_Usuario.ToString() == credenciales.contrasena
                                 select user).FirstOrDefault();

            Empleados? empleado = (from em in _context.Empleados
                                   where em.Correo == credenciales.correo
                                   && em.id_Empleados.ToString() == credenciales.contrasena
                                   select em).FirstOrDefault();

            if (usuario == null && empleado == null)
            {
                ViewBag.Mensaje = "Credenciales incorrectas!!";
                return View("Index");
            }

            //Si usuario es nulo, se asume que es un empleado
            if (usuario == null)
            {
                string datosEmpleado = JsonSerializer.Serialize(empleado);
                HttpContext.Session.SetString("empleado", datosEmpleado);

                if (empleado.Encargo == "Admin")
                {
                    ViewBag.Mensaje = "Bienvenido";
                    return RedirectToAction("IndexAdmin", "Home");
                }

                ViewBag.Mensaje = "Bienvenido";
                return RedirectToAction("IndexEmpleado", "Home");
            }

            if (empleado == null)
            {
                string datosUsuario = JsonSerializer.Serialize(usuario);

                HttpContext.Session.SetString("usuario", datosUsuario);

                ViewBag.Mensaje = "Bienvenido";
                return RedirectToAction("Index", "Home");
            }

            //Se usume que es un Usuario
            return View("Index");
        }


        // Método para registrar un empleado
        public IActionResult RegistrarEmpleado()
        {
            return RedirectToAction("Create", "Empleados");
        }

        // Método para registrar un cliente
        public IActionResult RegistrarCliente()
        {
            return RedirectToAction("Create", "Usuarios");
        }
    }
}
