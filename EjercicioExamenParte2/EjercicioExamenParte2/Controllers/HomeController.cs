using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjercicioExamenParte2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(bool? esMiPrimeraVez)
        {
            String cadena = "";

            if (esMiPrimeraVez == false)
            {
                cadena = "Es la primera vez que entras";
            }
            else
                cadena = "No es la primera vez que entras";

            ViewData["esMiPrimeraVez"] = cadena;

            return View();
        }
    }
}