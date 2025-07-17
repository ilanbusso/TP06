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
    public IActionResult IniciarSesion(string nombreIntegrante, string passIntegrante)
    {
        string view;
        Integrantes integrante = ObtenerIntegranteDesdeSession();  
        integrante = BD.devolverIntegrante(nombreIntegrante, passIntegrante);
        if (integrante == null)
        {
            ViewBag.mensaje = "Contraseña o Correo incorrectos, por favor verifique de vuelta";
            view = "Error";
        }

        else
        {
            view = "info";
            ViewBag.integrante = integrante;
            ViewBag.integrantes = BD.devolverGrupo(integrante);
        }
        GuardarIntegranteEnSession(integrante);
        return View(view);
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

