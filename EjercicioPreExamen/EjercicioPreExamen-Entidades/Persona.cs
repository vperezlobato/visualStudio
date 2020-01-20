using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPreExamen_Entidades
{
    public class Persona
    {

        public String DNI { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public int IDPuestoTrabajo { get; set; }
        public int IDDepartamento { get; set; }

        public Persona() { }

        public Persona(String DNI, String Nombre, String Apellidos, int IDPuestoTrabajo, int IDDepartamento) {
            this.DNI = DNI;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.IDPuestoTrabajo = IDPuestoTrabajo;
            this.IDDepartamento = IDDepartamento;
        }
    }
}
