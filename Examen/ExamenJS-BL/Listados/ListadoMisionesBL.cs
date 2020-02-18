using ExamenJS_DAL;
using ExamenJS_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenJS_BL
{
    public class ListadoMisionesBL
    {
        /// <summary>
        /// Este metodo devuelve el listado de misiones
        /// </summary>
        /// <returns>listado de misiones</returns>
        public List<Mision> listadoMisionesReservadasBL() {
            List<Mision> listadoMisiones = new List<Mision>();

            ListadoMisionesDAL list = new ListadoMisionesDAL();

            listadoMisiones = list.listadoMisionesReservadas();

            return listadoMisiones;
        }
    }
}
