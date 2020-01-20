using EjercicioPreExamen_BL.Listados;
using EjercicioPreExamen_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjercicioPreExamen.Models
{
    public class personaConNombreDepartamentoYNombrePuestoTrabajo : Persona
    {

        public String nombrePuestoTrabajo { get; set; }
        public String nombreDepartamento { get; set;}

        public personaConNombreDepartamentoYNombrePuestoTrabajo() {
        }
        public personaConNombreDepartamentoYNombrePuestoTrabajo(String DNI, String Nombre, String Apellidos, int IDPuestoTrabajo, int IDDepartamento, String nombrePuestoTrabajo ,String nombreDepartamento)
        {
            this.DNI = DNI;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.IDPuestoTrabajo = IDPuestoTrabajo;
            this.IDDepartamento = IDDepartamento;
            this.nombreDepartamento = nombreDepartamento;
            this.nombrePuestoTrabajo = nombrePuestoTrabajo;
        }
    }
}