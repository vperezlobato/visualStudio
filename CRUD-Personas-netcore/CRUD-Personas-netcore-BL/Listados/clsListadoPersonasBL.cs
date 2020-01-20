using CRUD_Personas_netcore_DAL;
using CRUD_Personas_netcore_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Personas_netcore_BL.Listados
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
