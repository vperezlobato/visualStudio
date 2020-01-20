using _07_CRUD_Personas_BL.Listados;
using _07_CRUD_Personas_BL.Services;
using _07_CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _07_CRUD_Personas_UI.Controllers
{
    public class PersonasApiController : ApiController
    {
 
        clsListadoPersonasBL listado = new clsListadoPersonasBL();
        gestionadoraPersonas_BL gestionadora = new gestionadoraPersonas_BL();
        // GET: api/PersonasAPI
        public IEnumerable<clsPersona> Get()
        {
            List<clsPersona> listadoPersonas = new List<clsPersona>();
            listadoPersonas = listado.listadoPersonas();
            return listadoPersonas;
        }

        // GET: api/PersonasAPI/5
        public clsPersona Get(int id)
        {
            return gestionadora.buscarPersona_BL(id);
        }

        // POST: api/PersonasAPI
        public void Post([FromBody]clsPersona value)
        {
            gestionadora.insertarPersona_BL(value);
        }

        // PUT: api/PersonasAPI/5
        public void Put(int id, [FromBody]clsPersona value)
        {
            value.idPersona = id;
            gestionadora.editarPersona_BL(value);
        }

        // DELETE: api/PersonasAPI/5
        public void Delete(int id)
        {
            gestionadora.borrarPersona_BL(id);
        }
    }
}
