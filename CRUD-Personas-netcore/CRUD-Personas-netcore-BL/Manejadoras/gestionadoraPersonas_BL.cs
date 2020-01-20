using CRUD_Personas_netcore_DAL.Services;
using CRUD_Personas_netcore_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Personas_netcore_BL.Services
{
    public class gestionadoraPersonas_BL
    {
        public int insertarPersona_BL(clsPersona objPersona)
        {
            int filas = 0;

            gestionadoraPersonas_DAL gestionadora = new gestionadoraPersonas_DAL();

            filas = gestionadora.insertarPersona_DAL(objPersona);

            return filas;

        }

        public int borrarPersona_BL(int id) 
        {
            int filas = 0;

            gestionadoraPersonas_DAL gestionadora = new gestionadoraPersonas_DAL();

            filas = gestionadora.borrarPersona_DAL(id);

            return filas;
        
        }

        public int editarPersona_BL(clsPersona objPersona) {
            int filas = 0;

            gestionadoraPersonas_DAL gestionadora = new gestionadoraPersonas_DAL();

            filas = gestionadora.editarPersona_DAL(objPersona);

            return filas;
        }

        public clsPersona buscarPersona_BL(int id) {
            clsPersona objPersona = new clsPersona();

            gestionadoraPersonas_DAL gestionadora = new gestionadoraPersonas_DAL();

            objPersona = gestionadora.buscarPersona_DAL(id);

            return objPersona;
        }

    }
}
