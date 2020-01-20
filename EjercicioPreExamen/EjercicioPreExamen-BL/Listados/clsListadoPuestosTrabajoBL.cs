using EjercicioPreExamen_DAL.Listados;
using EjercicioPreExamen_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPreExamen_BL.Listados
{
    public class clsListadoPuestosTrabajoBL
    {
        public List<PuestosTrabajo> listadoPuestosTrabajo()
        {
            List<PuestosTrabajo> listado = new List<PuestosTrabajo>();

            clsListadoPuestosTrabajo listadoDepartamentosDal = new clsListadoPuestosTrabajo();

            listado = listadoDepartamentosDal.listadoPuestosTrabajo();

            return listado;
        }

        public PuestosTrabajo puestoTrabajoPorID(int id)
        {
            clsListadoPuestosTrabajo listBBDD = new clsListadoPuestosTrabajo();
            PuestosTrabajo objDepartamento = new PuestosTrabajo();
            objDepartamento = listBBDD.puestoTrabajoPorID(id);

            return objDepartamento;
        }
    }
}
