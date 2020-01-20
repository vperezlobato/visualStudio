using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using _07_CRUD_Personas_Entidades;
using _07_CRUD_Personas_DAL;
using _07_CRUD_Personas_BL.Services;
using _07_CRUD_Personas_BL.Listados;

namespace _07_CRUD_Personas_UI
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost, ActionName("Index")]
        public ActionResult IndexPost()
        {
            try
            {
                SqlConnection miConexion = new SqlConnection();
                miConexion.ConnectionString = "server=victormanuel.database.windows.net;database=PersonasDB;uid=victor;pwd=mitesoro_97;";
                miConexion.Open();
                ViewData["estado"] = miConexion.State;
                return View();
            }
            catch
            {
                return View("vistaError");
            }
        }

        public ActionResult IndexLista()
        {


            return View();
        }

        public ActionResult listadoPersonas()
        {
            List<clsPersona> listadoPersonas = new List<clsPersona>();
            clsListadoPersonasDAL listado = new clsListadoPersonasDAL();
            listadoPersonas = listado.listadoPersonas();

            try
            {
                return View(listadoPersonas);
            }
            catch (Exception e)
            {
                return View("vistaError");
            }
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(clsPersona objPersona)
        {

            int filas = 0;
            gestionadoraPersonas_BL gestionadora = new gestionadoraPersonas_BL();
            clsListadoPersonasBL listarPersonas = new clsListadoPersonasBL();
            List<clsPersona> listado = new List<clsPersona>();

            if (ModelState.IsValid)
            {
                try
                {
                    filas = gestionadora.insertarPersona_BL(objPersona);
                    ViewData["comprobacion"] = $"Se ha insertado correctamente {filas} registro";
                    listado = listarPersonas.listadoPersonas();
                    return View("listadoPersona", listado);
                }
                catch (Exception e)
                {
                    return View("vistaError");
                }
            }
            else
                return View(objPersona);

            
        }

    }

}
