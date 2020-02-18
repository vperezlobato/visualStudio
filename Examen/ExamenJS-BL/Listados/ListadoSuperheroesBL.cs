using ExamenJS_DAL;
using ExamenJS_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenJS_BL
{
    public class ListadoSuperheroesBL
    {

        /// <summary>
        /// Este metodo ofrece un listado de superheroes
        /// </summary>
        /// <returns>List<Superheroe> listadoSuperheroes</returns>
        public List<Superheroe> listadoSuperheroesBL() {
            List<Superheroe> listadoSuperheroes = new List<Superheroe>();

            ListadoSuperheroesDAL list = new ListadoSuperheroesDAL();

            listadoSuperheroes = list.listadoSuperheroesDAL();

            return listadoSuperheroes;
        }

    }
}
