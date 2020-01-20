using _07_CRUD_Personas_DAL;
using _07_CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CRUD_Personas_BL.Listados
{
    public class clsListadoPersonasBL
    {
        public List<clsPersona> listadoPersonas() {

            List<clsPersona> listado = new List<clsPersona>();

            clsListadoPersonasDAL listadoPersonasDAL = new clsListadoPersonasDAL();

            listado = listadoPersonasDAL.listadoPersonas();

            return listado;
        }

    }
}
