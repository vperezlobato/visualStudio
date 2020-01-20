using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSGEMP_Victor_Entidades
{
    public class gestionadoraMisionesBL
    {
        /// <summary>
        /// Funcion que recibe como parametro un listado de misiones y edita los datos de cada mision en la DB
        /// </summary>
        /// <param name="objMision"></param>
        /// <returns>Devuelve el numero de filas afectadas</returns>
        public int actualizarMisionesBL(List<Mision> misiones)
        {
            int filasAfectadas = 0;

            gestionadoraMisiones gestionadora = new gestionadoraMisiones();

            filasAfectadas = gestionadora.actualizarMisionesDAL(misiones);

            return filasAfectadas;
        }


    }
}
