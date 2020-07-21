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
    public class ControlAdministrador
    {
        #region Atributos

        DataAccess dataAccess;
        Administrador administrador;

        #endregion

        #region Constructor

        public ControlAdministrador()
        {
            dataAccess = new DataAccess();
            administrador = new Administrador();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Ejecuta un comando select de la tabla administrador verificando el ingreso de usuario y contraseña 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contraseña"></param>
        /// <returns></returns>

        public Boolean Logined(String usuario, String contraseña)
        {

            return dataAccess.Logined(usuario, contraseña);

        }

        /// <summary>
        /// Crea un nuevo registro de un administrador en la base de datos
        /// </summary>
        /// <param name="Cedula"></param>
        /// <param name="Nombre"></param>
        /// <param name="Correo"></param>
        /// <param name="Usuario"></param>
        /// <param name="Contraseña"></param>
        /// <param name="Telefono"></param>
        /// <returns></returns>

        public Boolean RegistrarAdministrador(String cedula, String nombre, String correo, String usuario, String contraseña, String telefono)
        {

            administrador.Cedula = cedula;
            administrador.Nombre = nombre;
            administrador.Correo = correo;
            administrador.Usuario = usuario;
            administrador.Contraseña = contraseña;
            administrador.Telefono = telefono;

            return dataAccess.RegistrarAdministrador(administrador);

        }

        /// <summary>
        /// Consulta la existencia de un administrador por medio de su identificación 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public Boolean BuscarAdministrador(String cedula)
        {

            return dataAccess.BuscarAdministrador(cedula);

        }

        /// <summary>
        /// Devuelve un vector con la información consultada del admnistrador en la base de datos a través de su cedula 
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>

        public String[] InformacionAdministrador(String cedula)
        {

            administrador = dataAccess.InformacionAdministrador(cedula);

            String[] infoAdmin= new String[6];
            infoAdmin[0] = administrador.Cedula;
            infoAdmin[1] = administrador.Nombre;
            infoAdmin[2] = administrador.Correo;
            infoAdmin[3] = administrador.Usuario;
            infoAdmin[4] = administrador.Contraseña;
            infoAdmin[5] = administrador.Telefono;

            return infoAdmin;

        }

        /// <summary>
        /// Actualiza el registro de un administrador a partir de su cedula y devuelve verdadero si la modificación fue exitosa
        /// </summary>
        /// <param name="cedula"></param>
        /// <param name="nombre"></param>
        /// <param name="correo"></param>
        /// <param name="usuario"></param>
        /// <param name="contraseña"></param>
        /// <param name="telefono"></param>
        /// <returns></returns>

        public Boolean ModificarAdministrador(String cedula, String nombre, String correo, String usuario, String contraseña, String telefono)
        {

            administrador.Cedula = cedula;
            administrador.Nombre = nombre;
            administrador.Correo = correo;
            administrador.Usuario = usuario;
            administrador.Contraseña = contraseña;
            administrador.Telefono = telefono;

            return dataAccess.ModificarAdministrador(administrador);

        }

        /// <summary>
        /// Elimina el registro de la tabla administrador a partir de su cedula y devuelve verdadero si el borrado fue exitoso
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>

        public Boolean EliminarAdministrador(String cedula)
        {

            return dataAccess.EliminarAdministrador(cedula);

        }

        #endregion
    }
}
