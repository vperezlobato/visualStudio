using ExamenJS_BL;
using ExamenJS_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Examen_UI.Controllers
{
    public class SuperheroeController : ApiController
    {

        ListadoSuperheroesBL listado = new ListadoSuperheroesBL();
        // GET: api/Superheroe
        public IEnumerable<Superheroe> Get()
        {
            List<Superheroe> listadoSuperheroes = new List<Superheroe>();

            try
            {

                listadoSuperheroes = listado.listadoSuperheroesBL();
            }catch (Exception e) {
                throw e;
            }

            return listadoSuperheroes;
        }

    }
}
