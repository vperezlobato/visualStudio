using _08_Victor_Examen_DAL;
using _08_Victor_Examen_Entidades;
using _08_Victor_Examen_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _08_Victor_Examen_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            clsMainPageVM modeloVista = new clsMainPageVM();
            return View(modeloVista);
        }

        [HttpPost]
        public ActionResult Index(clsMainPageVM modeloVista, String botonPulsado) {
            clsListadoPersonasDAL list = new clsListadoPersonasDAL();
            List<clsPersona> listadoPersonas = new List<clsPersona>();
            gestionadoraPersonas_DAL gestionadora = new gestionadoraPersonas_DAL();

            if (botonPulsado == "Seleccionar departamento")
            {                            
                listadoPersonas = list.listadoPersonasPorIDDepartamento(modeloVista.personaSeleccionada.idDepartamento);
                modeloVista = new clsMainPageVM(listadoPersonas);
            }

            if (botonPulsado == "Ver Detalle" && modeloVista.personaSeleccionada.idPersona != 0)
                {
                    listadoPersonas = list.listadoPersonasPorIDDepartamento((modeloVista.personaSeleccionada.idDepartamento));
                    clsPersona persona = gestionadora.buscarPersona_DAL(modeloVista.personaSeleccionada.idPersona);
                    modeloVista = new clsMainPageVM(listadoPersonas, persona);
                }

            return View(modeloVista);            
        }
    }
}