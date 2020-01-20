using _07_CRUD_Personas_DAL.Listas;
using _07_CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CRUD_Personas_BL.Listados
{
    public class clsListadoDepartamentosBL
    {
        public List<clsDepartamento> listadoDepartamentos()
        {
            List<clsDepartamento> listado = new List<clsDepartamento>();

            clsListadoDepartamentosDAL listadoDepartamentosDal = new clsListadoDepartamentosDAL();

            listado = listadoDepartamentosDal.listadoDepartamentos();

            return listado;
        }

        public clsDepartamento departamentoPorID(int id)
        {
            clsListadoDepartamentosDAL listBBDD = new clsListadoDepartamentosDAL();
            clsDepartamento objDepartamento = new clsDepartamento();
            objDepartamento = listBBDD.departamentoPorID(id);

            return objDepartamento;
        }
    }
}
