using EjercicioPreExamen_BL.Listados;
using EjercicioPreExamen_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjercicioPreExamen.Models
{
    public class personaConNombreDepartamentoYNombrePuestoTrabajoYListados : personaConNombreDepartamentoYNombrePuestoTrabajo
    {

        public List<Departamentos> listadoDepartamentos { get; set; }
        public List<personaConNombreDepartamentoYNombrePuestoTrabajo> listadoPersonas { get; set; }

        public personaConNombreDepartamentoYNombrePuestoTrabajoYListados()
        {
            clsListadoDepartamentosBL cldbl = new clsListadoDepartamentosBL();
            listadoDepartamentos = cldbl.listadoDepartamentos();
            listadoPersonas = new List<personaConNombreDepartamentoYNombrePuestoTrabajo>();
        }

        public personaConNombreDepartamentoYNombrePuestoTrabajoYListados(List<personaConNombreDepartamentoYNombrePuestoTrabajo> listadoPersonas)
        {
            clsListadoDepartamentosBL cldbl = new clsListadoDepartamentosBL();
            listadoDepartamentos = cldbl.listadoDepartamentos();
            this.listadoPersonas = listadoPersonas;
        }



    }
}