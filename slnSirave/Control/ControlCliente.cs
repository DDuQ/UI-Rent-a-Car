using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Modelo;
using System.Windows.Forms;

namespace Control
{
    public class ControlCliente
    {
        #region Atributos

        Cliente cliente;
        DataAccess dataAccess;

        #endregion

        #region Constructor

        public ControlCliente()
        {
            dataAccess = new DataAccess();
            cliente = new Cliente();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Provee la información del cliente a través de su cédula.
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>

        public Boolean BuscarCliente(String cedula)
        {

            return dataAccess.BuscarCliente(cedula);

        }

        /// <summary>
        /// Crea registro de un cliente, con sus características en la base de datos.
        /// </summary>
        /// <param name="cedula"></param>
        /// <param name="nombre"></param>
        /// <param name="correo"></param>
        /// <param name="usuario"></param>
        /// <param name="contraseña"></param>
        /// <param name="telefono"></param>
        /// <returns></returns>

        public Boolean registrarCliente(String cedula, String nombre, String correo, String usuario, String contraseña, String telefono)
        {

            cliente.Cedula = cedula;
            cliente.Nombre = nombre;
            cliente.Correo = correo;
            cliente.Usuario = usuario;
            cliente.Contraseña = contraseña;
            cliente.Telefono = telefono;

            return dataAccess.registrarCliente(cliente);
        
        }

        /// <summary>
        /// Permite hacer cambios a las características de un cliente. 
        /// </summary>
        /// <param name="cedula"></param>
        /// <param name="nombre"></param>
        /// <param name="correo"></param>
        /// <param name="usuario"></param>
        /// <param name="contraseña"></param>
        /// <param name="telefono"></param>
        /// <returns></returns>

        public bool ModificarCliente(string cedula, string nombre, string correo, string usuario, string contraseña, string telefono)
        {

            cliente.Cedula = cedula;
            cliente.Nombre = nombre;
            cliente.Correo = correo;
            cliente.Usuario = usuario;
            cliente.Contraseña = contraseña;
            cliente.Telefono = telefono;

            return dataAccess.ModificarCliente(cliente);

        }

        /// <summary>
        /// retorna un Cliente con sus datos respectivos
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        public String[] informacaionCliente(String cedula)
        {

            cliente = dataAccess.informacionCliente(cedula);

            String[] infoCli = new String[6];

            infoCli[0] = cliente.Cedula;
            infoCli[1] = cliente.Nombre;
            infoCli[2] = cliente.Correo;
            infoCli[3] = cliente.Usuario;
            infoCli[4] = cliente.Contraseña;
            infoCli[5] = cliente.Telefono;

            return infoCli;

        }
        /// <summary>
        /// Deshace el registro de un cliente en la tabla cliente de la base de datos a través de su cédula.
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>

        public bool eliminarCliente(string cedula)
        {
            return dataAccess.eliminarCliente(cedula);
        }

        #endregion
    }
}
