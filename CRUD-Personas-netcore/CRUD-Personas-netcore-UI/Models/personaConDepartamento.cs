using CRUD_Personas_netcore_BL.Listados;
using CRUD_Personas_netcore_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Personas_netcore_UI.Models
{
    public class personaConDepartamento : clsPersona
    {

        private List<clsDepartamento> _listadoDepartamentos;

        public List<clsDepartamento> listadoDepartamentos {
            get { return _listadoDepartamentos; }
            set{ _listadoDepartamentos = value; }
        }
        public personaConDepartamento() {
            clsListadoDepartamentosBL listado = new clsListadoDepartamentosBL();
            _listadoDepartamentos = listado.listadoDepartamentos();
        }

        public personaConDepartamento(int idPersona,int idDepartamento, String nombre, String apellidos,String telefono, String direccion, DateTime fechaNacimiento,byte[] foto)
        {
            clsListadoDepartamentosBL listado = new clsListadoDepartamentosBL();
            _listadoDepartamentos = listado.listadoDepartamentos();
            this.idPersona = idPersona;
            this.nombre = nombre;
            this.idDepartamento = idDepartamento;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.direccion = direccion;
            this.fechaNacimiento = fechaNacimiento;
            this.foto = foto;
        }


    }
}