using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control
{
    public class ControlVehiculo
    {
        #region Atributos

        DataAccess dataAccess;
        Vehiculo vehiculo;

        #endregion

        #region Constructor

        public ControlVehiculo()
        {
            dataAccess = new DataAccess();
            vehiculo = new Vehiculo();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Realiza la búsqueda de un vehículo por medio de su placa (PK) y devuelve un verdadero si la busqueda es exitosa.
        /// </summary>
        /// <param name="placa">Primary Key</param>
        /// <returns></returns>

        public Boolean BuscarVehiculo(String placa)
        {

            return dataAccess.BuscarVehiculo(placa);

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

        public Boolean registrarVehiculo(String placa,String modelo,String gama, String marca,String capacidad,String observaciones, String precio)
        {

            vehiculo.Placa = placa;
            vehiculo.Modelo = modelo;
            vehiculo.Gama = gama;
            vehiculo.Marca = marca;
            vehiculo.Capacidad = Convert.ToInt32(capacidad);
            vehiculo.Observaciones = observaciones;
            vehiculo.Precio = Convert.ToDouble(precio);

            return dataAccess.registrarVehiculo(vehiculo);
            
        }

        /// <summary>
        /// Retorna la información del vehículo solicitado.
        /// </summary>
        /// <param name="placa"></param>
        /// <returns></returns>

        public String[] informacionVehiculo(String placa)
        {
            vehiculo = dataAccess.informacionVehiculo(placa);

            String[] infoVeh = new String[7];

            infoVeh[0] = vehiculo.Placa;
            infoVeh[1] = vehiculo.Modelo;
            infoVeh[2] = vehiculo.Gama;
            infoVeh[3] = vehiculo.Marca;
            infoVeh[4] = vehiculo.Capacidad.ToString();
            infoVeh[5] = vehiculo.Observaciones;
            infoVeh[6] = vehiculo.Precio.ToString();

            return infoVeh;

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

        public bool ModificarVehiculo(String placa, String modelo, String gama, String marca, String capacidad, String observaciones, String precio)
        {

            vehiculo.Placa = placa;
            vehiculo.Modelo = modelo;
            vehiculo.Gama = gama;
            vehiculo.Marca = marca;
            vehiculo.Capacidad = Convert.ToInt32(capacidad);
            vehiculo.Observaciones = observaciones;
            vehiculo.Precio = Convert.ToDouble(precio);

            return dataAccess.ModificarVehiculo(vehiculo);

        }

        /// <summary>
        /// Deshace el registro de un vehículo a través de su placa y retorna un verdadero si el cambio es exitoso.
        /// </summary>
        /// <param name="placa"></param>
        /// <returns></returns>

        public bool eliminarVehiculo(string placa)
        {

            return dataAccess.eliminarVehiculo(placa);

        }

        #endregion
    }
}
