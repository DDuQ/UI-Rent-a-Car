using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Modelo
{
    public class DataAccess
    {
        #region Atributos

        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader leer;

        #endregion

        #region Constructor

        public DataAccess()
        {
            conexion = new SqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.Cadena;
        }

        #endregion

        #region Metodos para abrir y cerrar la BD

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

        #endregion

        #region Métodos para el manejo de administrador

        /// <summary>
        /// Ejecuta un comando select de la tabla administrador verificando el ingreso de usuario y contraseña 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contraseña"></param>
        /// <returns></returns>

        public Boolean Logined(String usuario, String contraseña)
        {

            int contador = 0;

            try
            {
                abrir();

                comando = new SqlCommand("Select Cedula FROM Administrador WHERE Usuario=@Usuario AND Contraseña=@Contraseña", conexion);
                comando.Parameters.AddWithValue("@Usuario", usuario);
                comando.Parameters.AddWithValue("@Contraseña", contraseña);

                leer = comando.ExecuteReader();

                while (leer.Read())
                {
                    contador++;
                }

                cerrar();

                if (contador != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("El error fue " + ex.Message);
                cerrar();
                return false;

            }

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

        public Boolean RegistrarAdministrador(Administrador administrador)
        {
            try
            {
                abrir();

                comando = new SqlCommand("Insert Into Administrador(Cedula,Nombre,Correo,Usuario,Contraseña,Telefono) Values(@Cedula,@Nombre,@Correo,@Usuario,@Contraseña,@Telefono)", conexion);
                comando.Parameters.AddWithValue("@Cedula", administrador.Cedula);
                comando.Parameters.AddWithValue("@Nombre", administrador.Nombre);
                comando.Parameters.AddWithValue("@Correo", administrador.Correo);
                comando.Parameters.AddWithValue("@Usuario", administrador.Usuario);
                comando.Parameters.AddWithValue("@Contraseña", administrador.Contraseña);
                comando.Parameters.AddWithValue("@Telefono", administrador.Telefono);

                comando.ExecuteNonQuery();

                cerrar();

                return true;
            }
            catch (Exception ex)
            {
                cerrar();
                MessageBox.Show("El error fue " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Consulta la existencia de un administrador por medio de su identificación 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public Boolean BuscarAdministrador(String cedula)
        {
            Boolean res = false;

            comando = new SqlCommand("IF EXISTS (SELECT Cedula from Administrador WHERE cedula=@cedula) " +
                                    "BEGIN SELECT 'true' 'RESPUESTA' END " +
                                    "ELSE BEGIN SELECT 'false' 'RESPUESTA' END", conexion);

            /*comando.Parameters.Add("@id",System.Data.SqlDbType.VarChar);
            comando.Parameters["@id"].Value = id;*/
            comando.Parameters.AddWithValue("@cedula", cedula);

            try
            {
                abrir();

                leer = comando.ExecuteReader();

                while (leer.Read())
                {
                    res = Convert.ToBoolean(leer["RESPUESTA"].ToString());
                }

                cerrar();
            }
            catch (Exception ex)
            {
                cerrar();
                MessageBox.Show("El error fue " + ex.Message);
            }

            return res;
        }

        /// <summary>
        /// Devuelve un administrador y su información consultada en la base de datos a través de su cedula 
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>

        public Administrador InformacionAdministrador(String cedula)
        {
            Administrador administrador = new Administrador();

            comando = new SqlCommand("SELECT * From Administrador WHERE cedula = @cedula", conexion);
            comando.Parameters.AddWithValue("@cedula", cedula);

            try
            {
                abrir();

                leer = comando.ExecuteReader();

                while (leer.Read())
                {
                    administrador.Nombre = leer["Nombre"].ToString();
                    administrador.Correo = leer["Correo"].ToString();
                    administrador.Usuario = leer["Usuario"].ToString();
                    administrador.Contraseña = leer["Contraseña"].ToString();
                    administrador.Telefono = leer["Telefono"].ToString();
                }

                cerrar();
            }
            catch (Exception ex)
            {
                cerrar();
                MessageBox.Show("El error fue " + ex.Message);
            }

            return administrador;
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

        public Boolean ModificarAdministrador(Administrador administrador)
        {
            comando = new SqlCommand("UPDATE Administrador " +
                                    "SET Nombre = @nombre, Correo = @correo, Usuario = @usuario, Contraseña = @contraseña, Telefono = @telefono " +
                                    "WHERE Cedula = @cedula ", conexion);

            comando.Parameters.AddWithValue("@Cedula", administrador.Cedula);
            comando.Parameters.AddWithValue("@Nombre", administrador.Nombre);
            comando.Parameters.AddWithValue("@Correo", administrador.Correo);
            comando.Parameters.AddWithValue("@Usuario", administrador.Usuario);
            comando.Parameters.AddWithValue("@Contraseña", administrador.Contraseña);
            comando.Parameters.AddWithValue("@Telefono", administrador.Telefono);

            try
            {
                abrir();

                int rowsAffected = comando.ExecuteNonQuery();

                cerrar();

                if (rowsAffected == 1)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                cerrar();
                MessageBox.Show("El error fue " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Elimina el registro de la tabla administrador a partir de su cedula y devuelve verdadero si el borrado fue exitoso
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>

        public Boolean EliminarAdministrador(String cedula)
        {
            var respuesta = MessageBox.Show($"¿Está seguro de eliminar al administrador identificado con cédula {cedula}? de la base de datos", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (respuesta == DialogResult.OK)
            {
                comando = new SqlCommand("DELETE from Administrador " +
                                        "WHERE Cedula = @cedula ", conexion);

                comando.Parameters.AddWithValue("@cedula", cedula);

                try
                {
                    abrir();

                    int rowsAffected = comando.ExecuteNonQuery();

                    cerrar();

                    if (rowsAffected == 1)
                        return true;
                    else
                        return false;

                }
                catch (Exception ex)
                {
                    cerrar();
                    MessageBox.Show("El error fue " + ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Métodos para el manejo de Cliente

        /// <summary>
        /// Provee la información del cliente a través de su cédula.
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>

        public Boolean BuscarCliente(String cedula)
        {
            Boolean res = false;

            comando = new SqlCommand("IF EXISTS (SELECT Cedula from Cliente WHERE cedula = @cedula) " +
                                    "BEGIN SELECT 'true' 'RESPUESTA' END " +
                                    "ELSE BEGIN SELECT 'false' 'RESPUESTA' END", conexion);

            /*comando.Parameters.Add("@id",System.Data.SqlDbType.VarChar);
            comando.Parameters["@id"].Value = id;*/
            comando.Parameters.AddWithValue("@cedula", cedula);

            try
            {
                abrir();

                leer = comando.ExecuteReader();

                while (leer.Read())
                {
                    res = Convert.ToBoolean(leer["RESPUESTA"].ToString());
                }

                cerrar();
            }
            catch (Exception ex)
            {
                cerrar();
                Console.WriteLine("El error fue " + ex.Message);
            }

            return res;
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

        public Boolean registrarCliente(Cliente cliente)
        {
            try
            {
                abrir();

                comando = new SqlCommand("Insert Into Cliente(Cedula,Nombre,Correo,Usuario,Contraseña,Telefono) Values(@Cedula,@Nombre,@Correo,@Usuario,@Contraseña,@Telefono)", conexion);
                comando.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@Correo", cliente.Correo);
                comando.Parameters.AddWithValue("@Usuario", cliente.Usuario);
                comando.Parameters.AddWithValue("@Contraseña", cliente.Contraseña);
                comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);

                comando.ExecuteNonQuery();

                cerrar();

                return true;
            }
            catch (Exception ex)
            {
                cerrar();
                MessageBox.Show("El error fue " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Retorna la información de un cliente a través de su cédula.
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>

        public Cliente informacionCliente(String cedula)
        {
            Cliente cliente = new Cliente();

            comando = new SqlCommand("SELECT * From Cliente WHERE cedula = @cedula", conexion);
            comando.Parameters.AddWithValue("@cedula", cedula);

            try
            {
                abrir();

                leer = comando.ExecuteReader();

                while (leer.Read())
                {
                    cliente.Nombre = leer["Nombre"].ToString();
                    cliente.Correo = leer["Correo"].ToString();
                    cliente.Usuario = leer["Usuario"].ToString();
                    cliente.Contraseña = leer["Contraseña"].ToString();
                    cliente.Telefono = leer["Telefono"].ToString();
                }

                cerrar();
            }
            catch (Exception ex)
            {
                cerrar();
                MessageBox.Show("El error fue " + ex.Message);
            }

            return cliente;
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

        public bool ModificarCliente(Cliente cliente)
        {
            comando = new SqlCommand("UPDATE Cliente " +
                                    "SET Nombre = @nombre, Correo = @correo, Usuario = @usuario, Contraseña = @contraseña, Telefono = @telefono " +
                                    "WHERE Cedula = @cedula ", conexion);

            comando.Parameters.AddWithValue("@cedula", cliente.Cedula);
            comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
            comando.Parameters.AddWithValue("@correo", cliente.Correo);
            comando.Parameters.AddWithValue("@usuario", cliente.Usuario);
            comando.Parameters.AddWithValue("@contraseña", cliente.Contraseña);
            comando.Parameters.AddWithValue("@telefono", cliente.Telefono);

            try
            {
                abrir();

                int rowsAffected = comando.ExecuteNonQuery();

                cerrar();

                if (rowsAffected == 1)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                cerrar();
                MessageBox.Show("El error fue " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Deshace el registro de un cliente en la tabla cliente de la base de datos a través de su cédula.
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>

        public bool eliminarCliente(string cedula)
        {
            var respuesta = MessageBox.Show($"¿Está seguro de eliminar al cliente identificado con cédula {cedula}? de la base de datos", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (respuesta == DialogResult.OK)
            {
                comando = new SqlCommand("DELETE from Cliente " +
                                        "WHERE Cedula = @cedula ", conexion);

                comando.Parameters.AddWithValue("@cedula", cedula);

                try
                {
                    abrir();

                    int rowsAffected = comando.ExecuteNonQuery();

                    cerrar();

                    if (rowsAffected == 1)
                        return true;
                    else
                        return false;

                }
                catch (Exception ex)
                {
                    cerrar();
                    MessageBox.Show("El error fue " + ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Métodos para el manejo de Reserva

        /// <summary>
        ///  Añade las placas de los vehiculos existentes en la base de datos al ComboBox y lo retorna.
        /// </summary>
        /// <param name="cbxPlaca"></param>
        /// <returns></returns>

        public ComboBox cargarComboBoxDePlacas(ComboBox cbxPlaca)
        {
            comando = new SqlCommand("SELECT Placa from Vehiculo", conexion);

            try
            {
            abrir();

                leer = comando.ExecuteReader();

                while (leer.Read())
                {
                    cbxPlaca.Items.Add(leer["Placa"].ToString());
                }

            cerrar();
            }
            catch (Exception ex)
            {   
            cerrar();
                MessageBox.Show("El error fue: " + ex.Message);
            }

            return cbxPlaca;
        }

        /// <summary>
        /// Añade las cédulas de los clientes existentes en la base de datos al ComboBox y lo retorna.
        /// </summary>
        /// <param name="cbxCedula"></param>
        /// <returns></returns>

        public ComboBox cargarComboBoxDeCedulas(ComboBox cbxCedula)
        {
            comando = new SqlCommand("SELECT Cedula from Cliente", conexion);

            try
            {
                abrir();

                leer = comando.ExecuteReader();

                while (leer.Read())
                {
                    cbxCedula.Items.Add(leer["Cedula"].ToString());
                }

                cerrar();
            }
            catch (Exception ex)
            {
                cerrar();
                MessageBox.Show("El error fue: " + ex.Message);
            }

            return cbxCedula;
        }

        /// <summary>
        /// Consulta la información de un vehiculo, según de su disponibilidad.
        /// </summary>
        /// <param name="placa"></param>
        /// <returns></returns>

        public Vehiculo informacionVehiculoReservado(String placa)
        {
            Vehiculo vehiculo = new Vehiculo();

            comando = new SqlCommand("SELECT Disponibilidad, CedulaCliente, FechaInicioAlquiler, FechaFinAlquiler From Vehiculo WHERE Placa = @Placa", conexion);
            comando.Parameters.AddWithValue("@Placa", placa);

            try
            {
                abrir();

                leer = comando.ExecuteReader();

                while (leer.Read())
                {
                    vehiculo.Placa = placa;
                    vehiculo.Disponibilidad = (leer["Disponibilidad"].ToString());

                    if (vehiculo.Disponibilidad.Equals("En Reserva"))
                    {
                        vehiculo.CedulaCliente = (leer["CedulaCliente"].ToString());
                        vehiculo.FechaInicioAlquiler = DateTime.Parse(leer["FechaInicioAlquiler"].ToString());
                        vehiculo.FechaFinAlquiler = DateTime.Parse(leer["FechaFinAlquiler"].ToString());
                    }
                    else
                    {
                        vehiculo.CedulaCliente = null;
                    }
                }

                cerrar();
            }
            catch (Exception ex)
            {
                cerrar();
                MessageBox.Show("El error fue " + ex.Message);
            }

            return vehiculo;
        }

        /// <summary>
        /// Permite reservar un vehículo, modificando el estado de disponibilidad por un rango de tiempo.
        /// </summary>
        /// <param name="vehiculo"></param>
        /// <returns></returns>

        public Boolean realizarReserva(Vehiculo vehiculo)
        {
            try
            {
                comando = new SqlCommand("UPDATE vehiculo " +
                                    "SET CedulaCliente = @CedulaCliente, Disponibilidad = @Disponibilidad, FechaInicioAlquiler = @FechaInicioAlquiler, FechaFinAlquiler = @FechaFinAlquiler " +
                                    "WHERE Placa = @Placa", conexion);

                comando.Parameters.AddWithValue("@CedulaCliente", vehiculo.CedulaCliente.ToString());
                comando.Parameters.AddWithValue("@Disponibilidad", vehiculo.Disponibilidad.ToString());
                comando.Parameters.AddWithValue("@FechaInicioAlquiler", vehiculo.FechaInicioAlquiler);
                comando.Parameters.AddWithValue("@FechaFinAlquiler", vehiculo.FechaFinAlquiler);
                comando.Parameters.AddWithValue("@Placa", vehiculo.Placa.ToString());

                abrir();

                comando.ExecuteNonQuery();

                cerrar();

                return true;
            }
            catch (Exception ex)
            {
                cerrar();
                MessageBox.Show("El error fue " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Permite hacer cambios en el rango de tiempo en que se estipula la reserva.
        /// </summary>
        /// <param name="vehiculo"></param>
        /// <returns></returns>

        public bool modificarReserva(Vehiculo vehiculo)
        {
            try
            {
                comando = new SqlCommand("UPDATE vehiculo " +
                                    "SET FechaInicioAlquiler = @FechaInicioAlquiler, FechaFinAlquiler = @FechaFinAlquiler " +
                                    "WHERE Placa = @Placa", conexion);

                comando.Parameters.AddWithValue("@FechaInicioAlquiler", vehiculo.FechaInicioAlquiler);
                comando.Parameters.AddWithValue("@FechaFinAlquiler", vehiculo.FechaFinAlquiler);
                comando.Parameters.AddWithValue("@Placa", vehiculo.Placa.ToString());

                abrir();

                comando.ExecuteNonQuery();

                cerrar();

                return true;
            }
            catch (Exception ex)
            {
                cerrar();
                MessageBox.Show("El error fue " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Valida la opción de deshacer la reserva, actualiza el registro del vehiculo con placa recibida y devuelve verdadero si el proceso fue exitoso
        /// </summary>
        /// <param name="placa"></param>
        /// <returns></returns>

        public bool deshacerReserva(string placa)
        {
            var respuesta = MessageBox.Show($"¿Está seguro de deshacer la reserva al vehiculo con placa {placa}?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (respuesta == DialogResult.OK)
            {
                comando = new SqlCommand("UPDATE Vehiculo " +
                                    "SET Disponibilidad = 'Disponible', cedulaCliente = NULL, fechaInicioAlquiler = NULL, fechaFinAlquiler = NULL " +
                                    "WHERE Placa = @Placa ", conexion);

                comando.Parameters.AddWithValue("@Placa", placa);

                try
                {
                    abrir();

                    int rowsAffected = comando.ExecuteNonQuery();

                    cerrar();

                    if (rowsAffected == 1)
                        return true;
                    else
                        return false;

                }
                catch (Exception ex)
                {
                    cerrar();
                    MessageBox.Show("El error fue " + ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Métodos para el manejo de vehículos 

        /// <summary>
        /// Realiza la búsqueda de un vehículo por medio de su placa (PK) y devuelve un verdadero si la busqueda es exitosa.
        /// </summary>
        /// <param name="placa">Primary Key</param>
        /// <returns></returns>

        public Boolean BuscarVehiculo(String placa)
        {
            Boolean res = false;

            comando = new SqlCommand("IF EXISTS (SELECT Placa from Vehiculo WHERE Placa = @Placa) " +
                                "BEGIN SELECT 'true' 'RESPUESTA' END " +
                                "ELSE BEGIN SELECT 'false' 'RESPUESTA' END", conexion);

            /*comando.Parameters.Add("@id",System.Data.SqlDbType.VarChar);
            comando.Parameters["@id"].Value = id;*/
            comando.Parameters.AddWithValue("@Placa", placa);

            try
            {
                abrir();

                leer = comando.ExecuteReader();

                while (leer.Read())
                {
                    res = Convert.ToBoolean(leer["RESPUESTA"].ToString());
                }

                cerrar();
            }
            catch (Exception ex)
            {
                cerrar();
                MessageBox.Show("El error fue " + ex.Message);
            }

            return res;
        }

        /// <summary>
        /// Crea un nuevo registro de un vehículo (con sus características) en la base de datos y devuelve un verdadero si el registro es exitoso.
        /// </summary>
        /// <param name="placa"></param>
        /// <param name="modelo"></param>
        /// <param name="gama"></param>
        /// <param name="marca"></param>
        /// <param name="capacidad"></param>
        /// <param name="observaciones"></param>
        /// <param name="precio"></param>
        /// <returns></returns>

        public Boolean registrarVehiculo(Vehiculo vehiculo)
        {
            try
            {
                abrir();

                comando = new SqlCommand("Insert Into Vehiculo(Placa,Modelo,Gama,Marca,Capacidad,Observaciones, precio, disponibilidad) Values(@Placa,@Modelo,@Gama,@Marca,@Capacidad,@Observaciones,@precio,'Disponible')", conexion);
                comando.Parameters.AddWithValue("@Placa", vehiculo.Placa);
                comando.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
                comando.Parameters.AddWithValue("@Gama", vehiculo.Gama);
                comando.Parameters.AddWithValue("@Marca", vehiculo.Marca);
                comando.Parameters.AddWithValue("@Capacidad", vehiculo.Capacidad);
                comando.Parameters.AddWithValue("@Observaciones", vehiculo.Observaciones);
                comando.Parameters.AddWithValue("@precio", vehiculo.Precio);

                comando.ExecuteNonQuery();

                cerrar();

                return true;
            }
            catch (Exception ex)
            {
                cerrar();
                MessageBox.Show("El error fue " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Retorna la información del vehículo solicitado.
        /// </summary>
        /// <param name="placa"></param>
        /// <returns></returns>

        public Vehiculo informacionVehiculo(String placa)
        {
            Vehiculo vehiculo = new Vehiculo();

            comando = new SqlCommand("SELECT * From Vehiculo WHERE Placa = @Placa", conexion);
            comando.Parameters.AddWithValue("@Placa", placa);

            try
            {
                abrir();

                leer = comando.ExecuteReader();

                while (leer.Read())
                {
                    vehiculo.Placa = leer["Placa"].ToString();
                    vehiculo.Modelo = leer["Modelo"].ToString();
                    vehiculo.Gama = leer["Gama"].ToString();
                    vehiculo.Marca = leer["Marca"].ToString();
                    vehiculo.Capacidad = int.Parse(leer["Capacidad"].ToString());
                    vehiculo.Observaciones = leer["Observaciones"].ToString();
                    vehiculo.Precio = double.Parse(leer["Precio"].ToString());
                }

                cerrar();
            }
            catch (Exception ex)
            {
                cerrar();
                MessageBox.Show("El error fue " + ex.Message);
            }

            return vehiculo;
        }


        /// <summary>
        /// Cambia las caracterísitcas de un vehículo en la base de datos y devuelve un verdadero si los cambios son exitosos.
        /// </summary>
        /// <param name="placa"></param>
        /// <param name="modelo"></param>
        /// <param name="gama"></param>
        /// <param name="marca"></param>
        /// <param name="capacidad"></param>
        /// <param name="observaciones"></param>
        /// <param name="precio"></param>
        /// <returns></returns>

        public bool ModificarVehiculo(Vehiculo vehiculo)
        {
            comando = new SqlCommand("UPDATE Vehiculo " +
                                "SET Placa = @Placa, Modelo = @Modelo, Gama = @Gama, Marca = @Marca, Capacidad = @Capacidad, Observaciones = @Observaciones, Precio = @Precio  " +
                                "WHERE Placa = @Placa ", conexion);

            comando.Parameters.AddWithValue("@Placa", vehiculo.Placa);
            comando.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
            comando.Parameters.AddWithValue("@Gama", vehiculo.Gama);
            comando.Parameters.AddWithValue("@Marca", vehiculo.Marca);
            comando.Parameters.AddWithValue("@Capacidad", vehiculo.Capacidad);
            comando.Parameters.AddWithValue("@Observaciones", vehiculo.Observaciones);
            comando.Parameters.AddWithValue("@precio", vehiculo.Precio);

            try
            {
                abrir();

                int rowsAffected = comando.ExecuteNonQuery();

                cerrar();

                if (rowsAffected == 1)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                cerrar();
                MessageBox.Show("El error fue " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Deshace el registro de un vehículo a través de su placa y retorna un verdadero si el cambio es exitoso.
        /// </summary>
        /// <param name="placa"></param>
        /// <returns></returns>

        public bool eliminarVehiculo(string placa)
        {
            var respuesta = MessageBox.Show($"¿Está seguro de eliminar El vehiculo con placa {placa} de la base de datos?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (respuesta == DialogResult.OK)
            {
                comando = new SqlCommand("DELETE from Vehiculo " +
                                    "WHERE Placa = @Placa ", conexion);

                comando.Parameters.AddWithValue("@Placa", placa);

                try
                {
                    abrir();

                    int rowsAffected = comando.ExecuteNonQuery();

                    cerrar();

                    if (rowsAffected == 1)
                        return true;
                    else
                        return false;

                }
                catch (Exception ex)
                {
                    cerrar();
                    MessageBox.Show("El error fue " + ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}

