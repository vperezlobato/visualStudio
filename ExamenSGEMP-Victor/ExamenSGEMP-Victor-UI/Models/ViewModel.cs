using ExamenSGEMP_Victor_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenSGEMP_Victor_UI.Models
{
    public class ViewModel
    {

        private List<Superheroe> _listadoSuperheroes;
        private List<Mision> _listadoMisionesNoReservadas;
        private Mision _misionSeleccionadas;
        private Superheroe _superheroeSeleccionado;
        private List<Mision> _misionesSeleccionadas;
        //public bool check { get; set; }

        public ViewModel() {
            ListadoSuperheroesBL lsBL = new ListadoSuperheroesBL();
            _listadoSuperheroes = lsBL.listadoSuperheroesBL();
            ListadoMisionesBL lmBL = new ListadoMisionesBL();
            _listadoMisionesNoReservadas = lmBL.listadoMisionesNoReservadasBL();
            _misionesSeleccionadas = new List<Mision>();
            _misionSeleccionadas = new Mision();
        }

        public List<Superheroe> listadoSuperheroes {
            get { return _listadoSuperheroes; }
            set { _listadoSuperheroes = value; }
        }

        public List<Mision> listadoMisionesNoReservadas
        {
            get { return _listadoMisionesNoReservadas; }
            set { _listadoMisionesNoReservadas = value; }
        }

        public Mision misionSeleccionadas
        {
            get { return _misionSeleccionadas; }
            set { _misionSeleccionadas = value; }
        }

        public List<Mision> misionesSeleccionadas
        {
            get { return _misionesSeleccionadas; }
            set { _misionesSeleccionadas = value; }
        }

        public Superheroe superheroeSeleccionado
        {
            get { return _superheroeSeleccionado; }
            set { _superheroeSeleccionado = value; }
        }

    }
}