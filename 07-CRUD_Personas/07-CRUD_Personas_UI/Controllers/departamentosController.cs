using _07_CRUD_Personas_BL.Listados;
using _07_CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _07_CRUD_Personas_UI.Controllers
{
    public class departamentosController : ApiController
    {
        // GET: api/departamentos
        clsListadoDepartamentosBL listado = new clsListadoDepartamentosBL();
        public IEnumerable<clsDepartamento> Get()
        {
            return listado.listadoDepartamentos();
        }

        // GET: api/departamentos/5
        public clsDepartamento Get(int id)
        {
            return listado.departamentoPorID(id);
        }

    }
}
