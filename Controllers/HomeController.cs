using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06.Models;

namespace TP06.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Integrantes integrante = new Integrantes();
        HttpContext.Session.SetString("Integrantes", Objeto.ObjectToString(Integrantes));
        return View();
    }
    public IActionResult IniciarSesion(string mailIntegrante, string passIntegrante)
    {
        Integrantes integrantes = Objeto.StringToObject<Integrantes>(HttpContext.Session.GetString("Integrantes"));
        integrantes = BD.devolverEquipo(mailIntegrante, passIntegrante);
        if (integrantes = null)
        {
            ViewBag.mensaje = "Contraseña o Correo incorrectos, por favor verifique de vuelta";
            ViewBag.view = "Error";
        }
        
        else
        {
            ViewBag.view = "info";
            ViewBag.nombre = integrantes.nombre;
            ViewBag.estatura = integrantes.estatura;
            ViewBag.orientacion = integrantes.orientacion;
            ViewBag.sexo = integrantes.sexo;
            ViewBag.edad = integrantes.edad;
            ViewBag.peliculaFav = integrantes.peliculaFav;
        }
        HttpContext.Session.SetString("Integrantes", Objeto.ObjectToString(Integrantes));
        return View(ViewBag.view);
    }
}
