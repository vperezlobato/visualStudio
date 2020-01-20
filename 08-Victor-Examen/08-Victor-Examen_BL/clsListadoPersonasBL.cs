using _08_Victor_Examen_DAL;
using _08_Victor_Examen_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Victor_Examen_BL
{
    public class clsListadoPersonasBL
    {
        public List<clsPersona> listadoPersonas_BL() {

            List<clsPersona> listado = new List<clsPersona>();

            clsListadoPersonasDAL listadoPersonasDAL = new clsListadoPersonasDAL();

            listado = listadoPersonasDAL.listadoPersonas();

            return listado;
        }

        public Boolean existePersona_BL(int id)
        {

            Boolean existe = false;

            clsListadoPersonasDAL listadoPersonasDAL = new clsListadoPersonasDAL();

            existe = listadoPersonasDAL.existePersona_DAL(id);

            return existe;
        }
    }

}

