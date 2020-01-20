using EjercicioPreExamen_DAL;
using EjercicioPreExamen_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPreExamen_DAL
{
    public class clsListadoPersonasDAL
    {
        /// <summary>
        /// Metodo que devuelve un listado de personas de la BBDD.
        /// </summary>
        /// <returns></returns>
        public List<Persona> listadoPersonas() {
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            System.Type tipoDBNULL = DBNull.Value.GetType();
            List<Persona> listadoPersonas = new List<Persona>();
            Persona objPersona;

            try
            {
                miComando.CommandText = "SELECT * FROM Personas";
                miComando.Connection = connection;
                miLector = miComando.ExecuteReader();
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        objPersona = new Persona();
                        objPersona.IDPuestoTrabajo = miLector["IDPuestoTrabajo"].GetType() != tipoDBNULL ? (int)miLector["IDPuestoTrabajo"] : 0;
                        objPersona.DNI = miLector["DNI"].GetType() != tipoDBNULL ? (string)miLector["DNI"] : null;
                        objPersona.Apellidos = miLector["Apellidos"].GetType() != tipoDBNULL ? (string)miLector["Apellidos"] : null;
                        objPersona.Nombre = miLector["Nombre"].GetType() != tipoDBNULL ? (string)miLector["Nombre"] : null;
                        objPersona.IDDepartamento = miLector["IDDepartamento"].GetType() != tipoDBNULL ? (int)miLector["IDDepartamento"] : 0;
                        listadoPersonas.Add(objPersona);
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

            return listadoPersonas;
        }

        /// <summary>
        /// Metodo que devuelve un listado de personas de la BBDD.
        /// </summary>
        /// <returns></returns>
        public List<Persona> listadoPersonasPorIDDepartamento(int id)
        {
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            System.Type tipoDBNULL = DBNull.Value.GetType();
            List<Persona> listadoPersonas = new List<Persona>();
            Persona objPersona;

            try
            {
                miComando.CommandText = "SELECT * FROM Personas Where IDDepartamento = " + id;
                miComando.Connection = connection;
                miLector = miComando.ExecuteReader();
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        objPersona = new Persona();
                        objPersona.IDPuestoTrabajo = miLector["IDPuestoTrabajo"].GetType() != tipoDBNULL ? (int)miLector["IDPuestoTrabajo"] : 0;
                        objPersona.DNI = miLector["DNI"].GetType() != tipoDBNULL ? (string)miLector["DNI"] : null;
                        objPersona.Apellidos = miLector["Apellidos"].GetType() != tipoDBNULL ? (string)miLector["Apellidos"] : null;
                        objPersona.Nombre = miLector["Nombre"].GetType() != tipoDBNULL ? (string)miLector["Nombre"] : null;
                        objPersona.IDDepartamento = miLector["IDDepartamento"].GetType() != tipoDBNULL ? (int)miLector["IDDepartamento"] : 0;
                        listadoPersonas.Add(objPersona);
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

            return listadoPersonas;
        }

        /// <summary>
        /// Metodo para comprobar que existe la persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean existePersona_DAL(String DNI)
        {
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            Boolean existe = false;


            miComando.CommandText = "SELECT * FROM Empresa Where DNI =" + DNI;
            miComando.Connection = connection;
            miLector = miComando.ExecuteReader();

            if (miLector.HasRows)
            {
                existe = true;
            }

            miLector.Close();
            miConexion.closeConnection(ref connection);

            return existe;
        }
    }
    
}
