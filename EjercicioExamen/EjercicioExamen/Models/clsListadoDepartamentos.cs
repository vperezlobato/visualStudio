using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjercicioExamen.Models
{
    public class clsListadoDepartamentos
    {

        public List<clsDepartamento> departamentos() {
            List<clsDepartamento> listaDepartamentos = new List<clsDepartamento>
            {
                new clsDepartamento("Gestion", 1),
                new clsDepartamento("Finanzas", 2),
                new clsDepartamento("Ventas", 3),
                new clsDepartamento("Gestion de la cadena de suministros", 4)
            };

            return listaDepartamentos;
        }
    }
}