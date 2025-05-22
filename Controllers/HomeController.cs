using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AhorcadoTP04.Models;


namespace AhorcadoTP04.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
   
      
        
        
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
        {
            return View();
        }

        public IActionResult Jugar()
        {
            ViewBag.Palabra = Juego.VerPalabra();
            ViewBag.Intentos = Juego.intentos;
            ViewBag.Usadas = string.Join(" ", Juego.letrasUsadas);
            return View();
        }

        public IActionResult ArriesgarLetra(string letra)
        {
            if (letra != null)
            {
                Juego.ProbarLetra(char.ToUpper(letra[0]));
            }
            return RedirectToAction("Jugar");
        }

        public IActionResult ArriesgarPalabra(string palabra)
        {
            TempData["Mensaje"] = Juego.ArriesgarPalabra(palabra);
            return RedirectToAction("Resultado");
        }

        public IActionResult Resultado()
        {
            ViewBag.Mensaje = TempData["Mensaje"];
            return View();
        }
        
    }
