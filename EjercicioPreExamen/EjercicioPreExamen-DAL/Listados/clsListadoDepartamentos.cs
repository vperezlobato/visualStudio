using EjercicioPreExamen_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPreExamen_DAL.Listados
{
    public class clsListadoDepartamentos
    {
        public List<Departamentos> listadoDepartamentos()
        {

            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = miConexion.getConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader miLector = null;
            System.Type tipoDBNULL = DBNull.Value.GetType();
            Departamentos objDepartamento = new Departamentos();
            List<Departamentos> listado = new List<Departamentos>();


            try
            {
                comando.Connection = conexion;

                comando.CommandText = "Select * from Departamentos";
                miLector = comando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        objDepartamento = new Departamentos();
                        objDepartamento.ID = miLector["ID"].GetType() != tipoDBNULL ? (int)miLector["ID"] : 0;
                        objDepartamento.Nombre = miLector["Nombre"].GetType() != tipoDBNULL ? (string)miLector["Nombre"] : null;
                        listado.Add(objDepartamento);
                    }
                }
                miLector.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                miConexion.closeConnection(ref conexion);
            }
            return listado;
        }

        public Departamentos departamentoPorID(int id)
        {
            Departamentos objDepartamento = new Departamentos();
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                miComando.CommandText = "SELECT * FROM Departamentos WHERE ID  = " + id;
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        objDepartamento = new Departamentos();
                        objDepartamento.ID = (int)miLector["ID"];
                        objDepartamento.Nombre = (string)miLector["Nombre"];
                    }
                }
                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return objDepartamento;
        }
    }
}
