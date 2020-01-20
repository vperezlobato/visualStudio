using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _04_PasarDatosALaVista.Models
{
    public class clsListado
    {
        public List<clsPersona> listadoPersonas() {
            List<clsPersona> personas = new List<clsPersona>();

            personas.Add(new clsPersona("Victor","Perez","Lobato",new DateTime(1997,8,5)));
            personas.Add(new clsPersona("Victor", "Perez", "Lobato", new DateTime(1997, 8, 5)));
            personas.Add(new clsPersona("Victor", "Perez", "Lobato", new DateTime(1997, 8, 5)));
            personas.Add(new clsPersona("Victor", "Perez", "Lobato", new DateTime(1997, 8, 5)));

            return personas;
        }

    }
}