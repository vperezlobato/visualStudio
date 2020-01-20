using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_ConexionBBDD.Models
{
    public class clsPersona
    {
        
        public int idPersona { get; set; }
        public String nombre { get; set; }
        public String apellidos { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }

        public byte[] foto { get; set; }
        public int idDepartamento { get; set; }
        //constructor por defecto
        public clsPersona() {
        }

        //constructor por parametros
        public clsPersona(String nombre, String apellidos,DateTime fechaNac,String telefono,int idDepartamento, int idPersona,byte[] foto) {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNacimiento = fechaNac;
            this.telefono = telefono;
            this.idDepartamento = idDepartamento;
            this.idPersona = idPersona;
            this.foto = foto;
        }


    }
}
