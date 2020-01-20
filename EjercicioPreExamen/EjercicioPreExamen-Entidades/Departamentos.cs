using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPreExamen_Entidades
{
    public class Departamentos
    {
        public String Nombre { get; set; }

        public int ID { get; set; }

        public Departamentos() { }

        public Departamentos(String Nombre, int ID)
        {
            this.ID = ID;
            this.Nombre = Nombre;
        }
    }
}
