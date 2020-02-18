using ExamenJS_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenJS_DAL
{
    public class ListadoMisionesDAL
    {
        /// <summary>
        /// Este metodo devuelve el listado de misiones
        /// </summary>
        /// <returns>listado de misiones</returns>
        public List<Mision> listadoMisionesReservadas()
        {
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            System.Type tipoDBNULL = DBNull.Value.GetType();
            List<Mision> listadoMisiones = new List<Mision>();
            Mision objMision;

            try
            {
                miComando.CommandText = "SELECT * FROM misiones";
                miComando.Connection = connection;
                miLector = miComando.ExecuteReader();
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        objMision = new Mision();
                        objMision.idMision = miLector["idMision"].GetType() != tipoDBNULL ? (int)miLector["idMision"] : 0;
                        objMision.tituloMision = miLector["tituloMision"].GetType() != tipoDBNULL ? (string)miLector["tituloMision"] : null;
                        objMision.descripcionMision = miLector["descripcionMision"].GetType() != tipoDBNULL ? (string)miLector["descripcionMision"] : null;
                        objMision.reservada = miLector["reservada"].GetType() != tipoDBNULL ? (bool)miLector["reservada"] : false;
                        objMision.idSuperheroe = miLector["idSuperheroe"].GetType() != tipoDBNULL ? (int)miLector["idSuperheroe"] : 0;
                        objMision.observaciones = miLector["observaciones"].GetType() != tipoDBNULL ? (string)miLector["observaciones"] : null;
                        listadoMisiones.Add(objMision);
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

                miConexion.closeConnection(ref connection);
            }

            return listadoMisiones;
        }
    }
}
