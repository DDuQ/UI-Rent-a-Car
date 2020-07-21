using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    public class Conexion
    {

        SqlConnection conexion;
        /*SqlCommand comando;
        SqlDataReader leer;*/
        //String cadena = "Data Source = localhost; Initial Catalog = Sirave; Integrated Security = True";

        public Conexion()
        {
            conexion = new SqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cnn;
        }


        /// <summary>
        /// Abre la base de datos Sirave
        /// </summary>
        public void abrir()
        {
            try
            {
                conexion.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("El error fue " + ex);
            }
        }

        /// <summary>
        /// cierra la base de datos Sirave
        /// </summary>

        public void cerrar()
        {
            try
            {
                conexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("El error fue " + ex);
            }
        }

        /// <summary>
        /// obtiene la conexion con la base de datos Sirave
        /// </summary>
        /// <returns></returns>

        public SqlConnection getConexion()
        {
            return conexion;
        }

    }
}
