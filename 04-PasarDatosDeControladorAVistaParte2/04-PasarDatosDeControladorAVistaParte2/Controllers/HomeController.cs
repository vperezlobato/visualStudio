using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _04_PasarDatosDeControladorAVistaParte2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Editar()
        {
            clsPersona objPersona = new clsPersona();
            objPersona.nombre = "victor";
            objPersona.apellido1 = "perez";
            objPersona.apellido2 = "lobato";
            objPersona.direccion = "Coria";
            objPersona.fechaNacimiento = new DateTime(1997-8-5);
            objPersona.telefono = "111111111";
            return View(objPersona);
        }

        [HttpPost]
        public ActionResult Editar(clsPersona objPersona) {

            return View("PersonaModificada", objPersona);
        }
    }
}