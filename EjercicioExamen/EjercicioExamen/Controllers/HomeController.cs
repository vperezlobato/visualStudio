using EjercicioExamen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjercicioExamen.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Editar()
        {
            List<clsDepartamento> listadoDepartamentos;            
            clsListadoDepartamentos listado = new clsListadoDepartamentos();
            listadoDepartamentos = listado.departamentos();

            clsPersona objPersona = new clsPersona("Victor","Perez Lobato","Coria",new DateTime(2019-8-5),listadoDepartamentos.First());
            //no he conseguido lo del dropdown

            return View(objPersona);
        }

        [HttpPost]
        public ActionResult Editar(clsPersona objPersona)
        {

            return View("PersonaModificada", objPersona);
        }
    }
}