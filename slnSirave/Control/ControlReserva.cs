using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;

namespace Control
{
    public class ControlReserva
    {
        #region Atributos

        Vehiculo vehiculo;
        DataAccess dataAccess;
        
        #endregion

        #region constructor
        
        public ControlReserva()
        {
            vehiculo = new Vehiculo();
            dataAccess = new DataAccess();
        }

        #endregion

        #region Métodos
        /// <summary>
        ///  Añade las placas de los vehiculos existentes en la base de datos al ComboBox y lo retorna.
        /// </summary>
        /// <param name="cbxPlaca"></param>
        /// <returns></returns>

        public ComboBox cargarComboBoxDePlacas(ComboBox cbxPlaca)
        {

            return dataAccess.cargarComboBoxDePlacas(cbxPlaca); 

        }

        /// <summary>
        /// Añade las cédulas de los clientes existentes en la base de datos al ComboBox y lo retorna.
        /// </summary>
        /// <param name="cbxCedula"></param>
        /// <returns></returns>

        public ComboBox cargarComboBoxDeCedulas(ComboBox cbxCedula)
        {

            return dataAccess.cargarComboBoxDeCedulas(cbxCedula);

        }

        /// <summary>
        /// Retorna un vector con la información del vehiculo de placa recibida como parametro.
        /// </summary>
        /// <param name="placa"></param>
        /// <returns></returns>

        public Object[] informacionVehiculo(String placa)
        {
            Object[] vecVehiculo = new Object[11];

            vehiculo= dataAccess.informacionVehiculoReservado(placa);

            vecVehiculo[0] = vehiculo.Placa;
            vecVehiculo[1] = vehiculo.Modelo;
            vecVehiculo[2] = vehiculo.Gama;
            vecVehiculo[3] = vehiculo.Marca;
            vecVehiculo[4] = vehiculo.Capacidad;
            vecVehiculo[5] = vehiculo.Observaciones;
            vecVehiculo[6] = vehiculo.Precio;
            vecVehiculo[7] = vehiculo.Disponibilidad;
            vecVehiculo[8] = vehiculo.CedulaCliente;
            vecVehiculo[9] = vehiculo.FechaInicioAlquiler;
            vecVehiculo[10] = vehiculo.FechaFinAlquiler;

            return vecVehiculo;
        }

        /// <summary>
        /// Recibe un vector con la información del vehiculo a reservar, asignando esta información a un objeto vehiculo
        /// el cual es entregado al metodo realizar reserva de la clase dataAccess 
        /// retornando un booleano si la reservación fue o no exitosa.
        /// </summary>
        /// <param name="vehiculo"></param>
        /// <returns></returns>

        public Boolean realizarReserva(Object []vecVehiculo)
        {

            vehiculo.Placa = Convert.ToString(vecVehiculo[0]);
            vehiculo.Modelo = Convert.ToString(vecVehiculo[1]);
            vehiculo.Gama = Convert.ToString(vecVehiculo[2]);
            vehiculo.Marca = Convert.ToString(vecVehiculo[3]);
            vehiculo.Capacidad = Convert.ToInt32(vecVehiculo[4]);
            vehiculo.Observaciones = Convert.ToString(vecVehiculo[5]);
            vehiculo.Precio = Convert.ToDouble(vecVehiculo[6]);
            vehiculo.Disponibilidad = Convert.ToString(vecVehiculo[7]);
            vehiculo.CedulaCliente = Convert.ToString(vecVehiculo[8]);
            vehiculo.FechaInicioAlquiler = Convert.ToDateTime(vecVehiculo[9]);
            vehiculo.FechaFinAlquiler = Convert.ToDateTime(vecVehiculo[10]);

            return dataAccess.realizarReserva(vehiculo);

        }

        /// <summary>
        /// Recibe un vector con la información del vehiculo a modificar asignando esta información a un objeto vehiculo
        /// el cual es entregado al metodo realizar reserva de la clase dataAccess 
        /// retornando un booleano si la modificación fue o no exitosa.
        /// </summary>
        /// <param name="vehiculo"></param>
        /// <returns></returns>

        public bool modificarReserva(Object []vecVehiculo)
        {
            vehiculo.Placa = Convert.ToString(vecVehiculo[0]);
            vehiculo.Modelo = Convert.ToString(vecVehiculo[1]);
            vehiculo.Gama = Convert.ToString(vecVehiculo[2]);
            vehiculo.Marca = Convert.ToString(vecVehiculo[3]);
            vehiculo.Capacidad = Convert.ToInt32(vecVehiculo[4]);
            vehiculo.Observaciones = Convert.ToString(vecVehiculo[5]);
            vehiculo.Precio = Convert.ToDouble(vecVehiculo[6]);
            vehiculo.Disponibilidad = Convert.ToString(vecVehiculo[7]);
            vehiculo.CedulaCliente = Convert.ToString(vecVehiculo[8]);
            vehiculo.FechaInicioAlquiler = Convert.ToDateTime(vecVehiculo[9]);
            vehiculo.FechaFinAlquiler = Convert.ToDateTime(vecVehiculo[10]);

            return dataAccess.modificarReserva(vehiculo);

        }

        /// <summary>
        /// Realiza un llamado al metodo deshacerReserva de la clase dataAcces entregandole la placa del vehiculo
        /// al que se le desea eliminar la reserva, retornando un booleano si la eliminación fue o no exitosa.
        /// </summary>
        /// <param name="placa"></param>
        /// <returns></returns>

        public bool deshacerReserva(string placa)
        {

            return dataAccess.deshacerReserva(placa);
        
        }

        #endregion 
    }

}

