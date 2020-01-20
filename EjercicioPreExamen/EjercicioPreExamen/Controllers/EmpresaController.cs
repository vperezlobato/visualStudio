using EjercicioPreExamen.Models;
using EjercicioPreExamen_BL.Listados;
using EjercicioPreExamen_BL.Manejadoras;
using EjercicioPreExamen_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjercicioPreExamen.Controllers
{
    public class EmpresaController : Controller
    {


        public ActionResult listadoPersonas()
        {
            personaConNombreDepartamentoYNombrePuestoTrabajoYListados listadoPersonaConNombreDepartamentoYNombrePuestoTrabajoYListados = new personaConNombreDepartamentoYNombrePuestoTrabajoYListados();
            return View(listadoPersonaConNombreDepartamentoYNombrePuestoTrabajoYListados);
            
        }

        [HttpPost]
        public ActionResult listadoPersonas(personaConNombreDepartamentoYNombrePuestoTrabajoYListados personaConNombreDepartamentoYNombrePuestoTrabajoYListados)
        {
            List<personaConNombreDepartamentoYNombrePuestoTrabajo> listadoPersonaConNombreDepartamentoYNombrePuestoTrabajo = new List<personaConNombreDepartamentoYNombrePuestoTrabajo>();
            clsListadoPersonasBL clpbl = new clsListadoPersonasBL();
            clsListadoDepartamentosBL cldbl = new clsListadoDepartamentosBL();
            clsListadoPuestosTrabajoBL clptbl = new clsListadoPuestosTrabajoBL();
            List<Persona> listadoPersonas = new List<Persona>();

            try {
                listadoPersonas = clpbl.listadoPersonasPorIDDepartamento(personaConNombreDepartamentoYNombrePuestoTrabajoYListados.IDDepartamento);
                
                foreach(var item in listadoPersonas) {
                    personaConNombreDepartamentoYNombrePuestoTrabajo persona = new personaConNombreDepartamentoYNombrePuestoTrabajo();
                    persona.DNI = item.DNI;
                    persona.Apellidos = item.Apellidos;
                    persona.Nombre = item.Nombre;
                    persona.nombreDepartamento = cldbl.departamentoPorID(item.IDDepartamento).Nombre;
                    persona.nombrePuestoTrabajo = clptbl.puestoTrabajoPorID(item.IDPuestoTrabajo).Nombre;
                    listadoPersonaConNombreDepartamentoYNombrePuestoTrabajo.Add(persona);
                }
                personaConNombreDepartamentoYNombrePuestoTrabajoYListados = new personaConNombreDepartamentoYNombrePuestoTrabajoYListados(listadoPersonaConNombreDepartamentoYNombrePuestoTrabajo);
                return View(personaConNombreDepartamentoYNombrePuestoTrabajoYListados);
            } catch (Exception e)
            {
                return View("vistaError");
            }
        }

        public ActionResult Borrar(String DNI)
        {
            clsManejadoraPersonasBL gestionadoraPBL = new clsManejadoraPersonasBL();
            clsListadoDepartamentosBL clDBL = new clsListadoDepartamentosBL();
            clsListadoPuestosTrabajoBL clptbl = new clsListadoPuestosTrabajoBL();

            Persona persona = new Persona();
            Departamentos departamento = new Departamentos();
            PuestosTrabajo puestoTrabajo = new PuestosTrabajo();
            personaConNombreDepartamentoYNombrePuestoTrabajo objPersonaConNombreDepartamentoYNombrePuestoTrabajo = new personaConNombreDepartamentoYNombrePuestoTrabajo();
            persona = gestionadoraPBL.buscarPersona_BL(DNI);
            departamento = clDBL.departamentoPorID(persona.IDDepartamento);
            puestoTrabajo = clptbl.puestoTrabajoPorID(persona.IDPuestoTrabajo);

            objPersonaConNombreDepartamentoYNombrePuestoTrabajo = new personaConNombreDepartamentoYNombrePuestoTrabajo(persona.DNI, persona.Nombre, persona.Apellidos, persona.IDPuestoTrabajo, persona.IDDepartamento, departamento.Nombre, puestoTrabajo.Nombre);

            return View(objPersonaConNombreDepartamentoYNombrePuestoTrabajo);

        }

        [HttpPost, ActionName("Borrar")]
        public ActionResult BorrarPost(String DNI)
        {

            int filas = 0;
            clsManejadoraPersonasBL gestionadora = new clsManejadoraPersonasBL();

            try
            {
                filas = gestionadora.borrarPersona_BL(DNI);
                ViewData["comprobacion"] = $"Se ha borrado correctamente {filas} registro";
                return View("vistaComprobacion");
            }
            catch (Exception e)
            {
                return View("vistaError");
            }

        }
    }
}