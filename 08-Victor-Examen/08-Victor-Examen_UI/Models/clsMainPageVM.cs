using _08_Victor_Examen_BL;
using _08_Victor_Examen_DAL;
using _08_Victor_Examen_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _08_Victor_Examen_UI.Models
{
    public class clsMainPageVM
    {
        //propiedades privadas
        private List<clsDepartamento> _listadoDepartamentos;
        private clsPersona _personaSeleccionada;
        private List<clsPersona> _listadoPersonas;
        
        //constructores
        public clsMainPageVM() {
            clsListadoDepartamentosBL list = new clsListadoDepartamentosBL();
            _listadoDepartamentos = list.listadoDepartamentos();
            _listadoPersonas = new List<clsPersona>();
        }

        public clsMainPageVM(List<clsPersona> listadoPersonas)
        {
            clsListadoDepartamentosBL list = new clsListadoDepartamentosBL();
            _listadoDepartamentos = list.listadoDepartamentos();
            _listadoPersonas = listadoPersonas;
        }

        public clsMainPageVM(List<clsPersona> listadoPersonas,clsPersona persona)
        {
            clsListadoDepartamentosBL list = new clsListadoDepartamentosBL();
            _listadoDepartamentos = list.listadoDepartamentos();
            _listadoPersonas = listadoPersonas;
            personaSeleccionada = persona;
        }

        public List<clsDepartamento> listadoDepartamentos {
            get { return _listadoDepartamentos; }
            set { _listadoDepartamentos = value; }
        }

        public clsPersona personaSeleccionada
        {
            get { return _personaSeleccionada; }
            set { _personaSeleccionada = value; }
        }

        public List<clsPersona> listadoPersonas
        {
            get { return _listadoPersonas; }
            set { _listadoPersonas = value; }
        }

    }
}