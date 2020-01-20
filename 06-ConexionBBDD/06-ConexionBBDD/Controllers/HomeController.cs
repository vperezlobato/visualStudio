using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using _06_ConexionBBDD.Models;

namespace _06_ConexionBBDD.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost,ActionName("Index")]
        public ActionResult IndexPost() {
            try
            {
                SqlConnection miConexion = new SqlConnection();
                miConexion.ConnectionString = "server=victormanuel.database.windows.net;database=PersonasDB;uid=victor;pwd=mitesoro_97;";
                miConexion.Open();
                ViewData["Error"] = miConexion.State;
                return View();
            }
            catch
            {
                return View("vistaError");
            }     
        }

        public ActionResult IndexLista() {


            return View();
        }

        public ActionResult listadoPersonas()
        {

            SqlConnection miConexion = new SqlConnection();
            miConexion.ConnectionString = "server=victormanuel.database.windows.net;database=PersonasDB;uid=victor;pwd=mitesoro_97;";

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            List<clsPersona> listadoPersonas = new List<clsPersona>();
            clsPersona oPersona;

            try
            {
                miConexion.Open();
                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)
                miComando.CommandText = "SELECT * FROM PD_Personas";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new clsPersona();
                        oPersona.idPersona = (int)miLector["IDPersona"];
                        oPersona.nombre = (string)miLector["NombrePersona"];
                        oPersona.apellidos = (string)miLector["ApellidosPersona"];
                        oPersona.fechaNacimiento = (DateTime)miLector["FechaNacimientoPersona"];
                        oPersona.direccion = (string)miLector["Direccion"];
                        oPersona.telefono = (string)miLector["TelefonoPersona"];
                        oPersona.idDepartamento = (int)miLector["IDDepartamento"];
                        listadoPersonas.Add(oPersona);
                    }
                }
                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }


            return View(listadoPersonas);
        }

    }
}