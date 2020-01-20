using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSGEMP_Victor_Entidades
{
    public class gestionadoraMisiones
    {

        /// <summary>
        /// Funcion que recibe como parametro un listado de misiones y edita los datos de cada mision en la DB
        /// </summary>
        /// <param name="objMision"></param>
        /// <returns>Devuelve el numero de filas afectadas</returns>
        public int actualizarMisionesDAL(List<Mision> misiones)
        {

            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection conexion = miConexion.getConnection();
            SqlCommand comando = new SqlCommand();
            int filas = 0;
            int totalFilasModificadas = 0;

            try
            {
                
                foreach (var item in misiones)
                {
                    comando.Connection = conexion;

                    comando.Parameters.Add("@reservada", System.Data.SqlDbType.Bit).Value = item.reservada;

                    comando.Parameters.Add("@idSuperheroe", System.Data.SqlDbType.Int).Value = item.idSuperheroe;

                    comando.Parameters.Add("@idMision", System.Data.SqlDbType.Int).Value = item.idMision;

                    comando.CommandText = "UPDATE misiones SET reservada = @reservada, idSuperheroe = @idSuperheroe Where idMision = @idMision ";

                    filas = comando.ExecuteNonQuery();
                    totalFilasModificadas += filas;
                    comando.Parameters.RemoveAt("@reservada");
                    comando.Parameters.RemoveAt("@idSuperheroe");
                    comando.Parameters.RemoveAt("@idMision");
                }
                 
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                miConexion.closeConnection(ref conexion);
            }
            return totalFilasModificadas;

        }
    }
}
