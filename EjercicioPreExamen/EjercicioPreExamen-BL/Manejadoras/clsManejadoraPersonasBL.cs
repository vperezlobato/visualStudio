using EjercicioPreExamen_DAL.Manejadoras;
using EjercicioPreExamen_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPreExamen_BL.Manejadoras
{
    public class clsManejadoraPersonasBL
    {
        public Persona buscarPersona_BL(String DNI)
        {
            Persona objPersona = new Persona();

            clsManejadoraPersonas gestionadora = new clsManejadoraPersonas();

            objPersona = gestionadora.buscarPersona_DAL(DNI);

            return objPersona;
        }

        public int borrarPersona_BL(String DNI)
        {
            int filas = 0;

            clsManejadoraPersonas gestionadora = new clsManejadoraPersonas();

            filas = gestionadora.borrarPersona_DAL(DNI);

            return filas;

        }
    }
}
