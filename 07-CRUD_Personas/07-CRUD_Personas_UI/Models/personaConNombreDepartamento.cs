using _07_CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _07_CRUD_Personas_UI.Models
{
    public class personaConNombreDepartamento : clsPersona
    {
        private String _nombreDepartamento;

        public String nombreDepartamento
        {
            get { return _nombreDepartamento; }
            set { _nombreDepartamento = value; }
        }

        public personaConNombreDepartamento(int idPersona, int idDepartamento, string nombre, string apellidos,DateTime fechaNacimiento, String direccion, String telefono, string nombreDep,byte[] foto)
        {

            this.idPersona = idPersona;
            this.idDepartamento = idDepartamento;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNacimiento = fechaNacimiento;
            this.direccion = direccion;
            this.telefono = telefono;
            this.nombreDepartamento = nombreDep;
            this.foto = foto;
        }

        public personaConNombreDepartamento() { }
    }
}