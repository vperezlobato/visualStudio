using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _05_Validaciones.Models
{
    public class clsPersonaConDepartamento
    {
        public List<clsDepartamento> listado { get; set; }
        public clsPersona objPersona { get; set; }
        public clsPersonaConDepartamento()
        {
            clsListadoDepartamentos listado = new clsListadoDepartamentos();
            this.listado = listado.departamentos();
            objPersona = new clsPersona();
        }
        
    }
}