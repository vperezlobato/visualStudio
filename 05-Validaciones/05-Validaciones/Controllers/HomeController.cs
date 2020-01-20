using _05_Validaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _05_Validaciones.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        
        public ActionResult Editar()
        {
            clsPersona objPersona = new clsPersona(1,"Victor","Perez","Coria",new DateTime(2019-8-5),"666666666");

            return View(objPersona);
        }

        [HttpPost]
        public ActionResult Editar(clsPersona objPersona)
        {

            if (!ModelState.IsValid)
            {
                return View(objPersona);
            }
            else
                return View("PersonaModificada",objPersona);
        }
    }
}