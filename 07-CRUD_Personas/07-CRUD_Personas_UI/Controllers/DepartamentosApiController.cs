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
    public class DepartamentosApiController : ApiController
    {
        clsListadoDepartamentosBL listado = new clsListadoDepartamentosBL();
        // GET: api/DepartamentosApi
        public IEnumerable<clsDepartamento> Get()
        {
            return listado.listadoDepartamentos();
        }

    }
}
