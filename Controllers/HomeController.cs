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
        GuardarIntegranteEnSession(integrante);
        return View();
    }
    public IActionResult IniciarSesion(string mailIntegrante, string passIntegrante)
    {
        Integrantes integrante = ObtenerIntegranteDesdeSession();  
        integrante = BD.devolverIntegrante(mailIntegrante, passIntegrante);
        if (integrante == null)
        {
            ViewBag.mensaje = "Contraseña o Correo incorrectos, por favor verifique de vuelta";
            ViewBag.view = "Error";
        }

        else
        {
            ViewBag.view = "info";
            ViewBag.nombre = integrante.nombre;
            ViewBag.estatura = integrante.estatura;
            ViewBag.orientacion = integrante.orientacion;
            ViewBag.sexo = integrante.sexo;
            ViewBag.edad = integrante.edad;
            ViewBag.peliculaFav = integrante.peliculaFav;
        }
        HttpContext.Session.SetString("Integrantes", Objeto.ObjectToString(integrante));
        return View(ViewBag.view);
    }
        private void GuardarIntegranteEnSession(Integrantes integrante) //Para guardar el objeto integrante en la sesión(guarda la informacion de jugador a medida que avanza)
    {
        HttpContext.Session.SetString("Integrantes", Objeto.ObjectToString(integrante));
    }

    private Integrantes ObtenerIntegranteDesdeSession()//Busca si un jugador ya tiene un integrante en sesión, si no lo tiene crea uno nuevo
    {
        Integrantes integrante = Objeto.StringToObject<Integrantes>(HttpContext.Session.GetString("Integrantes"));
        
        return integrante;

    }
}

