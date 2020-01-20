using EjercicioPreExamen_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPreExamen_DAL.Listados
{
    public class clsListadoPuestosTrabajo
    {
        public List<PuestosTrabajo> listadoPuestosTrabajo()
        {

            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = miConexion.getConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader miLector = null;
            System.Type tipoDBNULL = DBNull.Value.GetType();
            PuestosTrabajo objPuestoTrabajo = new PuestosTrabajo();
            List<PuestosTrabajo> listado = new List<PuestosTrabajo>();


            try
            {
                comando.Connection = conexion;

                comando.CommandText = "Select * from PuestosTrabajos";
                miLector = comando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        objPuestoTrabajo = new PuestosTrabajo();
                        objPuestoTrabajo.ID = miLector["ID"].GetType() != tipoDBNULL ? (int)miLector["ID"] : 0;
                        objPuestoTrabajo.Nombre = miLector["Nombre"].GetType() != tipoDBNULL ? (string)miLector["Nombre"] : null;
                        listado.Add(objPuestoTrabajo);
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

        public PuestosTrabajo puestoTrabajoPorID(int id)
        {
            PuestosTrabajo objPuestoTrabajo = new PuestosTrabajo();
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                miComando.CommandText = "SELECT * FROM PuestosTrabajos WHERE ID  = " + id;
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        objPuestoTrabajo = new PuestosTrabajo();
                        objPuestoTrabajo.ID = (int)miLector["ID"];
                        objPuestoTrabajo.Nombre = (string)miLector["Nombre"];
                    }
                }
                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return objPuestoTrabajo;
        }
    }
}
