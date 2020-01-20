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
using _07_CRUD_Personas_UI.Models;
using System.IO;

namespace _07_CRUD_Personas_UI
{
    public class HomeController : Controller
    {
        public ActionResult listadoPersonas()
        {
            List<personaConNombreDepartamento> personasConDpto = new List<personaConNombreDepartamento>();
            clsListadoDepartamentosBL cld = new clsListadoDepartamentosBL();
            clsListadoPersonasBL clpBL = new clsListadoPersonasBL();
            List<clsPersona> listado = new List<clsPersona>();

            try
            {
                listado = clpBL.listadoPersonas();
                foreach (var item in listado)
                {
                    personaConNombreDepartamento objPersona = new personaConNombreDepartamento();
                    objPersona.nombre = item.nombre;
                    objPersona.apellidos = item.apellidos;
                    objPersona.telefono = item.telefono;
                    objPersona.fechaNacimiento = item.fechaNacimiento;
                    objPersona.idPersona = item.idPersona;
                    objPersona.foto = item.foto;
                    objPersona.direccion = item.direccion;
                    objPersona.idDepartamento = item.idDepartamento;
                    objPersona.nombreDepartamento = cld.departamentoPorID(item.idDepartamento).nombre;
                    objPersona.foto = item.foto;
                    personasConDpto.Add(objPersona);
                }
                return View(personasConDpto);
            }
            catch (Exception e)
            {
                return View("vistaError");
            }
        }

        public ActionResult Create() {
            personaConDepartamento persona = new personaConDepartamento();
            return View(persona);
        }

        [HttpPost]
        public ActionResult Create(clsPersona objPersona, HttpPostedFileBase ImageData)
        {
            byte[] imageBytes;
            int filas = 0;
            gestionadoraPersonas_BL gestionadora = new gestionadoraPersonas_BL();

            if (ModelState.IsValid)
            {
                try
                {
                    ConvertirImagenAByte conversor = new ConvertirImagenAByte();
                    if (ImageData != null)
                    {
                        imageBytes = conversor.ConvertToBytes(ImageData);
                        if (objPersona.foto == null)
                        {
                            objPersona.foto = imageBytes;
                        }
                    }                    

                    filas = gestionadora.insertarPersona_BL(objPersona);
                    ViewData["comprobacion"] = $"Se ha insertado correctamente {filas} registro";
                    return View("vistaComprobacion");
                }
                catch (Exception e)
                {
                    return View("vistaError");
                }
            }
            else
                return View();
            
        }

        public ActionResult Delete(int id)
        {
            gestionadoraPersonas_BL gestionadoraPBL = new gestionadoraPersonas_BL();
            clsListadoDepartamentosBL clDBL = new clsListadoDepartamentosBL();

            clsPersona persona = new clsPersona();
            clsDepartamento departamento = new clsDepartamento();
            personaConNombreDepartamento objPersonaConNombreDepartamento = new personaConNombreDepartamento();
            persona = gestionadoraPBL.buscarPersona_BL(id);
            departamento = clDBL.departamentoPorID(persona.idDepartamento);

            objPersonaConNombreDepartamento = new personaConNombreDepartamento(persona.idPersona, persona.idDepartamento, persona.nombre, persona.apellidos, persona.fechaNacimiento, persona.direccion, persona.telefono, departamento.nombre,persona.foto);

            return View(objPersonaConNombreDepartamento);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeletePost(int id) {

            int filas = 0;
            gestionadoraPersonas_BL gestionadora = new gestionadoraPersonas_BL();

                try
                {
                    filas = gestionadora.borrarPersona_BL(id);
                    ViewData["comprobacion"] = $"Se ha borrado correctamente {filas} registro";
                    return View("vistaComprobacion");
                }
                catch (Exception e)
                {
                    return View("vistaError");
                }

        }

        public ActionResult Edit(int id)
        {
            gestionadoraPersonas_BL gestionadora = new gestionadoraPersonas_BL();
            clsPersona persona = new clsPersona();
            persona = gestionadora.buscarPersona_BL(id);
            personaConDepartamento personaConDept = new personaConDepartamento(persona.idPersona, persona.idDepartamento, persona.nombre, persona.apellidos, persona.telefono, persona.direccion, persona.fechaNacimiento, persona.foto);

            return View(personaConDept);
        }

        [HttpPost,ActionName("Edit")]
        public ActionResult Edit(clsPersona objPersona, HttpPostedFileBase ImageData)
        {
            byte[] imageBytes;
            int filas = 0;
            gestionadoraPersonas_BL gestionadora = new gestionadoraPersonas_BL();
            ConvertirImagenAByte conversor;
            if (ModelState.IsValid)
            {
                try
                {
                    conversor = new ConvertirImagenAByte();
                    if (ImageData != null)
                    {
                        imageBytes = conversor.ConvertToBytes(ImageData);
                        if (objPersona.foto == null)
                        {
                            objPersona.foto = imageBytes;
                        }
                    }

                    filas = gestionadora.editarPersona_BL(objPersona);
                    ViewData["comprobacion"] = $"Se ha modificado correctamente {filas} registro";
                    return View("vistaComprobacion");
                }
                catch (Exception e)
                {
                    return View("vistaError");
                }
            }
            else
                return View();
        }


        public ActionResult Details(int id)
        {
            gestionadoraPersonas_BL gestionadoraPBL = new gestionadoraPersonas_BL();
            clsListadoDepartamentosBL clDBL = new clsListadoDepartamentosBL();

            clsPersona persona = new clsPersona();
            clsDepartamento departamento = new clsDepartamento();
            personaConNombreDepartamento objPersonaConNombreDepartamento = new personaConNombreDepartamento();
            persona = gestionadoraPBL.buscarPersona_BL(id);
            departamento = clDBL.departamentoPorID(persona.idDepartamento);

            objPersonaConNombreDepartamento = new personaConNombreDepartamento(persona.idPersona,persona.idDepartamento,persona.nombre,persona.apellidos,persona.fechaNacimiento,persona.direccion,persona.telefono,departamento.nombre, persona.foto);

            return View(objPersonaConNombreDepartamento);
        }

    }

}
