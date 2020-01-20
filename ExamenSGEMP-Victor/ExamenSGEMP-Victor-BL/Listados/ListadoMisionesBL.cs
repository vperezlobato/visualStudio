using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSGEMP_Victor_Entidades
{
    public class ListadoMisionesBL
    {
        /// <summary>
        /// Este metodo devuelve el listado de misiones que no estan reservadas
        /// </summary>
        /// <returns></returns>
        public List<Mision> listadoMisionesNoReservadasBL() {
            List<Mision> listadoMisiones = new List<Mision>();

            ListadoMisionesDAL list = new ListadoMisionesDAL();

            listadoMisiones = list.listadoMisionesNoReservadas();

            return listadoMisiones;
        }
    }
}
