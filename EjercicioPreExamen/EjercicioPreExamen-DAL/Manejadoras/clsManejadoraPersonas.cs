using EjercicioPreExamen_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPreExamen_DAL.Manejadoras
{
    public class clsManejadoraPersonas
    {

        /// <summary>
        /// Funcion que recibe como parametro un entero id y devuelve la persona correspondiente a ese id. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve un objeto persona</returns>
        public Persona buscarPersona_DAL(String DNI)
        {
            Persona objPersona = new Persona();

            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = miConexion.getConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader miLector = null;
            System.Type tipoDBNULL = DBNull.Value.GetType();

            try
            {
                comando.Connection = conexion;
                comando.Parameters.Add("@DNI", System.Data.SqlDbType.Char).Value = DNI;
                comando.CommandText = "Select * From Personas Where DNI = @DNI";
                miLector = comando.ExecuteReader();

                if (miLector.HasRows)
                {
                    miLector.Read();

                    objPersona.IDPuestoTrabajo = miLector["IDPuestoTrabajo"].GetType() != tipoDBNULL ? (int)miLector["IDPuestoTrabajo"] : 0;
                    objPersona.DNI = miLector["DNI"].GetType() != tipoDBNULL ? (string)miLector["DNI"] : null;
                    objPersona.Apellidos = miLector["Apellidos"].GetType() != tipoDBNULL ? (string)miLector["Apellidos"] : null;
                    objPersona.Nombre = miLector["Nombre"].GetType() != tipoDBNULL ? (string)miLector["Nombre"] : null;
                    objPersona.IDDepartamento = miLector["IDDepartamento"].GetType() != tipoDBNULL ? (int)miLector["IDDepartamento"] : 0;
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
            return objPersona;
        }

        /// <summary>
        /// Funcion que recibe como parametro un entero id y borra a la persona correspondiente de ese id en la DB
        /// </summary>
        /// <param name="DNI"></param>
        /// <returns>Devuelve el numero de filas afectadas</returns>
        public int borrarPersona_DAL(String DNI)
        {
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = miConexion.getConnection();
            int filas = 0;
            SqlCommand comando = new SqlCommand();

            try
            {
                comando.Connection = conexion;

                comando.Parameters.Add("@DNI", System.Data.SqlDbType.Char).Value = DNI;
                comando.CommandText = "Delete FROM Personas Where DNI = @DNI";

                filas = comando.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                miConexion.closeConnection(ref conexion);
            }
            return filas;
        }
    }
}
