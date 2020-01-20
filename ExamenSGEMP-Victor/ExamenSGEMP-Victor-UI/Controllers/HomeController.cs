using ExamenSGEMP_Victor_Entidades;
using ExamenSGEMP_Victor_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenSGEMP_Victor_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            ViewModel modeloVista = new ViewModel();

            return View(modeloVista);
        }

        [HttpPost]
        public ActionResult Index(ViewModel modeloVista, int[] objetosSeleccionados) {
            int filas = 0;
            gestionadoraMisionesBL gestionadora = new gestionadoraMisionesBL();

                try
                {
                    foreach(var item in objetosSeleccionados)
                    {
                        modeloVista.misionSeleccionadas = new Mision();
                        modeloVista.misionSeleccionadas.idMision = item;
                        modeloVista.misionSeleccionadas.idSuperheroe = modeloVista.superheroeSeleccionado.idSuperheroe;
                        modeloVista.misionSeleccionadas.reservada = true;
                        modeloVista.misionesSeleccionadas.Add(modeloVista.misionSeleccionadas);
                    }
                    
                    filas = gestionadora.actualizarMisionesBL(modeloVista.misionesSeleccionadas);
                    ViewData["comprobacion"] = $"Se ha modificado correctamente {filas} registro";
                    return View("vistaComprobacion");
                }
                catch (Exception e)
                {
                    return View("vistaError");
                }

        }
    }
}