using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjercicioExamen.Models
{
    public class clsPersona
    {
        public String nombre { set; get; }

        public String apellidos { set; get; }

        public String direccion { set; get; }

        public DateTime fechaNacimiento { set; get; }

        public clsDepartamento departamento { set; get; }

        public clsPersona(String nombre, String apellidos, String direccion, DateTime fechaNacimiento, clsDepartamento departamento)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.direccion = direccion;
            this.fechaNacimiento = fechaNacimiento;
            this.departamento = departamento;
        }
    }
}