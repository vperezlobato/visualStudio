using _04_PasarDatosALaVista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _04_PasarDatosALaVista.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            int horaActual = DateTime.Now.Hour;                            
            ViewBag.FechaActual = DateTime.Now;
            string saludo = "";

            clsPersona objPersona = new clsPersona();
            objPersona.nombre = "Victor";
            objPersona.apellido1 = "Perez";
            objPersona.apellido2 = "Lobato";
            objPersona.fechaNacimiento = new DateTime(1997,8,5);
            objPersona.telefono = "666666666";
            objPersona.direccion = "Coria";

            if (horaActual >= 6 && horaActual <= 12) {
                saludo = "Buenos dias";
            } else
                if (horaActual >= 13 && horaActual <= 20) {
                saludo = "Buenas tardes";
            }else
                saludo = "Buenas noches";

            ViewData["saludo"] = saludo;

            return View(objPersona);
        }
        public ActionResult listadoPersonas()
        {
            clsListado listadoPersonas = new clsListado();

            return View(listadoPersonas);
        }
    }
   
}