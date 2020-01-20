using EjercicioPreExamen_DAL.Listados;
using EjercicioPreExamen_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPreExamen_BL.Listados
{
    public class clsListadoDepartamentosBL
    {

        public List<Departamentos> listadoDepartamentos()
        {
            List<Departamentos> listado = new List<Departamentos>();

            clsListadoDepartamentos listadoDepartamentosDal = new clsListadoDepartamentos();

            listado = listadoDepartamentosDal.listadoDepartamentos();

            return listado;
        }

        public Departamentos departamentoPorID(int id)
        {
            clsListadoDepartamentos listBBDD = new clsListadoDepartamentos();
            Departamentos objDepartamento = new Departamentos();
            objDepartamento = listBBDD.departamentoPorID(id);

            return objDepartamento;
        }
    

    }
}
