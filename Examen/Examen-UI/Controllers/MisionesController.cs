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
    public class MisionesController : ApiController
    {

        ListadoMisionesBL listado = new ListadoMisionesBL();
        // GET: api/Misiones
        public IEnumerable<Mision> Get()
        {
            List<Mision> listadoMisiones = new List<Mision>();
            try {
                listadoMisiones = listado.listadoMisionesReservadasBL();
            } catch (Exception e) {
                throw e;
            }

            return listadoMisiones;
        }

    }
}
