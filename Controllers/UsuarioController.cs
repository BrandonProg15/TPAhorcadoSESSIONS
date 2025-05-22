using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TPAhorcado.Controllers;
public class UsuarioController : Controller
{
    [HttpGet]
    public IActionResult Registrar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Registrar(string nombre, string clave, string dni)
    {
        var usuario = new Usuario(nombre, clave, dni);

        // Guardar objeto serializado
        HttpContext.Session.SetString("usuario", Objeto.ObjectToString(usuario));

        // Guardar nombre separado
        HttpContext.Session.SetString("nombreUsuario", nombre);

        return RedirectToAction("Bienvenida");
    }

    public IActionResult Bienvenida()
    {
        // Recuperar objeto desde Session
        var json = HttpContext.Session.GetString("usuario");
        var usuario = Objeto.StringToObject<Usuario>(json);

        // Recuperar nombre como string separado
        var nombre = HttpContext.Session.GetString("nombreUsuario");

        // Pasar valores con ViewBag
        ViewBag.Nombre = usuario.Nombre;
        ViewBag.Clave = usuario.Clave;
        ViewBag.Dni = usuario.ObtenerDni();
        ViewBag.usuarioActual = usuario;
        ViewBag.NombreDesdeString = nombre;

        return View();
    }
}