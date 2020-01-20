using EjercicioPreExamen_DAL;
using EjercicioPreExamen_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPreExamen_BL.Listados
{
    public class clsListadoPersonasBL
    {
        public List<Persona> listadoPersonas()
        {

            List<Persona> listado = new List<Persona>();

            clsListadoPersonasDAL listadoPersonasDAL = new clsListadoPersonasDAL();

            listado = listadoPersonasDAL.listadoPersonas();

            return listado;
        }

        public List<Persona> listadoPersonasPorIDDepartamento(int id)
        {

            List<Persona> listado = new List<Persona>();

            clsListadoPersonasDAL listadoPersonasDAL = new clsListadoPersonasDAL();

            listado = listadoPersonasDAL.listadoPersonasPorIDDepartamento(id);

            return listado;
        }
    }
}
